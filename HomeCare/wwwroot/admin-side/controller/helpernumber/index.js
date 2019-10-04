// Admin HelperNumber page


var isRowCountChange = null;      // check whether rowcount changes


function registerEvent() {

    //Init validation
    $('#frmHelperNumber').validate({
        errorClass: 'red',
        ignore: [],
        lang: 'en',
        rules: {
            txtAmount: {
                required: true,
                number: true
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


    $("#btnCreate").on("click", function () {
        resethelpernumberform();
        $("#modalHelperNumber").modal("show");
    });


    $("#btnClose").on("click", function () {
        resethelpernumberform();        
    });


    $("#btnCancel").on("click", function () {
        resethelpernumberform();
    });


    $("body").on("click", ".btn-edit", function (e) {
        e.preventDefault();
        var that = $(this).data("id");

        $.ajax({
            type: "GET",
            url: "/Admin/Helpernumber/GetById",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                $("#HeNuId").val(res.Id);
                $("#txtAmount").val(res.Amount);

                $("#modalHelperNumber").modal("show");

            },
            error: function () {
                homecare.notify("Cannot load specified helpernumber", "error");
            }
        });
    });


    $("#btnSave").on("click", function (e) {
        if ($('#frmHelperNumber').valid()) {
            e.preventDefault();

            var id = $("#HeNuId").val();
            var amount = $("#txtAmount").val();

            $.ajax({
                type: "POST",
                url: "/Admin/Helpernumber/SaveEntity",
                data: {
                    Id: id,
                    Amount: amount
                },
                dataType: "json",
                success: function (res) {

                    if (res.Success === 1) {
                        $("#modalHelperNumber").modal("hide");
                        resethelpernumberform();
                        homecare.notify(res.Message, "success");

                        loadData();
                    }

                    if (res.Success === 0) {
                        homecare.notify(res.Message, "error");
                    }

                    if (res.Success === 2) {
                        homecare.notify(res.Message, "info");
                    }
                },
                error: function () {
                    homecare.notify("Error Occurred", "error");
                }
            });
        }
        else {
            homecare.notify("Invalid Form", "error");
        }
    });


    $("body").on("click", ".btn-delete", function (e) {
        e.preventDefault();
        var that = $(this).data("id");

        homecare.confirm("Attention", "Do you wanna delete this helpernumber ?", function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Helpernumber/Delete",
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


function resethelpernumberform() {
    $("#HeNuId").val(0);
    $("#txtAmount").val(0);
}


function loadData(isPageChanged) {

    $.ajax({
        type: "GET",
        url: "/Admin/Helpernumber/GetAllPaging",
        data: {
            keyword: $("#txtKeyword").val(),
            page: homecare.configs.pageIndex,
            pageSize: homecare.configs.pageSize
        },
        dataType: "json",
        success: function (res) {

            if (res.RowCount === 0) {
                $("#tbl-content").empty();
                homecare.notify("Can not find specified helpernumber", "info");
            }
            else {

                var template = $("#table-template").html();
                var render = "";

                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        amount: homecare.getHelperNumber(item.Amount)                        
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
            homecare.notify("Cannot load helpernumber data", "error");
        }
    });

}