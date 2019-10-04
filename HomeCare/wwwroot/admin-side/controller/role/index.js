// admin role page

var isRowCountChange = null;   // check whether rowcount changes

function registerEvents() {

    $("#frmRole").validate({
        errorClass: "red",
        ignore: [],
        lang: "en",
        rules: {
            txtName: {
                required: true
            },
            txtDescription: {
                required: true
            }
        }
    });

    $("#ddlShowPage").on("change", function () {
        homecare.configs.pageIndex = 1;
        homecare.configs.pageSize = $(this).val();
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
        resetroleform();
        $("#modalRole").modal("show");
    });

    $("#btnClose").on("click", function () {
        resetroleform();
    });

    $("#btnCancel").on("click", function () {
        resetroleform();
    });

    $("body").on("click", ".btn-edit", function (e) {

        e.preventDefault();
        var ID = $(this).data("id");

        $.ajax({
            type: "GET",
            url: "/Admin/Role/GetById",
            data: {
                id: ID
            },
            dataType: "json",
            success: function (res) {

                $("#RoleId").val(res.Id);
                $("#txtName").val(res.Name);
                $("#txtDescription").val(res.Description);

                $("#modalRole").modal("show");

            },
            error: function () {
                homecare.notify("Can not load specified Role", "error");
            }
        });

    });

    $("#btnSave").on("click", function (e) {
        if ($("#frmRole").valid()) {
            e.preventDefault();
            var id = $("#RoleId").val();
            var name = $("#txtName").val();
            var description = $("#txtDescription").val();

            $.ajax({
                type: "POST",
                url: "/Admin/Role/SaveEntity",
                data: {
                    Id: id,
                    Name: name,
                    Description: description
                },
                dataType: "json",
                success: function (res) {

                    if (res.Success === 1) {
                        $("#modalRole").modal("hide");
                        resetroleform();
                        homecare.notify(res.Message, "success");
                        loadData();
                    }
                    if (res.Success === 0) {
                        homecare.notify(res.Message, "info");
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


    $("body").on("click", ".btn-delete",function (e) {
        e.preventDefault();
        var id = $(this).data("id");

        homecare.confirm("Attention", "Do you wanna delete this role ?", function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Role/Delete",
                data: {
                    Id: id
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

function resetroleform() {

    $("#RoleId").val("");
    $("#txtName").val("");
    $("#txtDescription").val("");

}

function loadData(isPageChanged) {

    $.ajax({
        type: "GET",
        url: "/Admin/Role/GetAllPaging",
        data: {
            keyword: $("#txtKeyword").val(),
            page: homecare.configs.pageIndex,
            pageSize: homecare.configs.pageSize
        },
        dataType: "json",
        success: function (res) {

            if (res.RowCount === 0) {
                $("#tbl-content").empty();
                homecare.notify("Can not find specified role", "info");
            }
            else {

                var template = $("#table-template").html();
                var render = "";

                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        name: item.Name,
                        description: item.Description
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
            homecare.notify("Cannot load role data", "error");
        }
    });

}