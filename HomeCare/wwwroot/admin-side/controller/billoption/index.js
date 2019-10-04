// admin bill option page

var isRowCountChange = null;   // check whether rowcount changes


function registerEvents() {

    $("#frmBillOption").validate({
        errorClass: "red",
        ignore: [],
        lang: "en",
        rules: {
            txtWorkinghours: {
                required: true
            },
            txtAcreage: {
                required: true,
                number: true
            },
            txtRooms: {
                required: true,
                number: true
            },
            txtPrice: {
                required: true,
                number: true
            },
            txtNumberHelper: {
                required: true
            }
        }
    });

    $("#ddlShowPage").on("change", function () {
        homecare.configs.pageSize = $(this).val();
        homecare.configs.pageIndex = 1;
        loadData(true);
    });


    $("#btnSearch").on("click", function () {
        loadData();
    });


    $("#txtKeyword").on("keypress", function (e) {
        if (e.which === 13) {
            loadData();
        }
    });


    $("#btnClose").on("click", function () {
        resetbilloptionform();
    });

    $("#btnCancel").on("click", function () {
        resetbilloptionform();
    });

    $("#btnCreate").on("click", function () {
        resetbilloptionform();
        disablebilloptionfeild(true);
        $("#modalBillOption").modal("show");
    });

    $("body").on("click", ".btn-edit", function (e) {
        e.preventDefault();
        var that = $(this).data("id");

        $.ajax({
            type: "GET",
            url: "/Admin/BillOption/GetById",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                $("#BillOptionId").val(res.Id);
                $("#txtWorkinghours").val(res.Workinghours);
                $("#txtAcreage").val(res.Acreage);
                $("#txtRooms").val(res.Rooms);
                $("#txtPrice").val(res.Price);
                $("#txtCreatedDate").val(res.DateCreated);
                $("#txtModifiedDate").val(res.DateModified);
                $("#txtNumberHelper").val(res.NumberHelper);
                $("#ckStatus").prop("checked", res.Status === 1);

                disablebilloptionfeild(true);

                $("#modalBillOption").modal("show");

            },
            error: function () {
                homecare.notify("Can not load specified Bill Option", "error");
            }
        });
    });


    $("#btnSave").on("click", function (e) {
        if ($("#frmBillOption").valid()) {
            e.preventDefault();

            var id = $("#BillOptionId").val();
            var workinghours = $("#txtWorkinghours").val();
            var acreage = $("#txtAcreage").val();
            var room = $("#txtRooms").val();
            var price = $("#txtPrice").val();
            var createddate = $("#txtCreatedDate").val();
            var modifydate = $("#txtModifiedDate").val();
            var numberhelper = $("#txtNumberHelper").val();
            var status = $("#ckStatus").prop("checked") === true ? 1 : 0;

            $.ajax({
                type: "POST",
                url: "/Admin/BillOption/SaveEntity",
                data: {
                    Id: id,
                    Workinghours: workinghours,
                    Acreage: acreage,
                    Rooms: room,
                    Price: price,
                    DateCreated: createddate,
                    DateModified: modifydate,
                    Status: status,
                    NumberHelper: numberhelper
                },
                dataType: "json",
                success: function (res) {

                    if (res.Success === 0) {
                        homecare.notify(res.Message, "error");
                    }
                    if (res.Success === 1) {
                        $("#modalBillOption").modal("hide");
                        resetbilloptionform();
                        homecare.notify(res.Message, "success");
                        loadData();
                    }

                },
                error: function () {
                    homecare.notify("Error Occurred","error");
                }
            });

        }
        else {
            homecare.notify("Invalid Form","error");
        }
    });


    $("body").on("click", ".btn-delete", function (e) {
        e.preventDefault();
        var that = $(this).data("id");

        homecare.confirm("Attention", "Do you wanna delete this billoption ?", function () {
            $.ajax({
                type: "POST",
                url: "/Admin/BillOption/Delete",
                data: {
                    id: that
                },
                dataType: "json",
                success: function () {
                    loadData();
                    homecare.notify('Successfully deleted', 'success');
                },
                error: function () {
                    homecare.notify('Has an error in deleting process', 'error');
                }
            });
        });
    });
}


function loadHelperNumber() {
    $.ajax({
        type: "GET",
        url: "/Admin/Helpernumber/GetAll",
        dataType: "json",
        success: function (res) {

            var template = $('#table-template-helpernumber').html();

            var render = "";

            $.each(res, function (i, item) {
                render += Mustache.render(template, {
                    helpernumberId: item.Id,
                    helpernumberamount: item.Amount
                });
            });

            $('#txtNumberHelper').html(render);

        },
        error: function () {
            homecare.notify("Can not load Helper Number", "error");
        }
    });
}


function disablebilloptionfeild(disabled) {
    $("#txtCreatedDate").prop("disabled", disabled);
    $("#txtModifiedDate").prop("disabled", disabled);
}


function resetbilloptionform() {
    disablebilloptionfeild(false);
    $("#BillOptionId").val(0);
    $("#txtWorkinghours").val("");
    $("#txtAcreage").val(0);
    $("#txtRooms").val(0);
    $("#txtPrice").val(0);
    $("#txtCreatedDate").val("");
    $("#txtModifiedDate").val("");
    $("#txtNumberHelper").val(0);
    $("#ckStatus").prop("checked", true);
}


function loadData(isPageChanged) {

    $.ajax({
        type: "GET",
        url: "/Admin/BillOption/GetAllPaging",
        data: {
            keyword: $("#txtKeyword").val(),
            page: homecare.configs.pageIndex,
            pageSize: homecare.configs.pageSize
        },
        dataType: "json",
        success: function (res) {

            if (res.RowCount === 0) {
                $("#tbl-content").empty();
                homecare.notify("Can not find specified bill option", "info");
            }
            else {

                var template = $("#table-template").html();
                var render = "";
                var denomination = null;

                $.each(res.Results, function (i, item) {
                    denomination = item.Price + "<sup>vnd</sup>";

                    render += Mustache.render(template, {
                        Id: item.Id,
                        workinghours: item.Workinghours,
                        acreage: item.Acreage,
                        rooms: item.Rooms,
                        price: denomination,
                        status: homecare.getStatus(item.Status)                  
                    });
                });

                if (render !== "") {
                    $("#tbl-content").html(render);
                }

            }

            $("#lblTotalRecords").text(res.RowCount);

            var totalsize = Math.ceil(res.RowCount / homecare.configs.pageSize);

            if (isRowCountChange === null) {
                isRowCountChange = res.RowCount;
            }


            //Unbind pagination if it existed or click change pagesize
            if ($('#paginationUL a').length === 0 || isPageChanged === true || isRowCountChange !== res.RowCount) {
                isPageChanged = false;
                isRowCountChange = res.RowCount;
                $('#paginationUL').empty();
                $('#paginationUL').removeData("twbs-pagination");
                $('#paginationUL').unbind("page");
            }
            if (res.RowCount === 0) {
                $('#datatable-checkbox_info').hide();
            }


            //Bind Pagination Event
            if (res.RowCount !== 0) {
                $('#datatable-checkbox_info').show();
                $('#paginationUL').twbsPagination({
                    totalPages: totalsize,
                    visiblePages: 7,
                    onPageClick: function (event, p) {
                        homecare.configs.pageIndex = p;
                        setTimeout(loadData(), 200);
                    }
                });
            }

        },
        error: function () {
            homecare.notify("Cannot load bill option data", "error");
        }
    });

}