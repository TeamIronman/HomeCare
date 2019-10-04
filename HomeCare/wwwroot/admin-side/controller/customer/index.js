// customer management for admin page

var isRowCountChange = null;   // check whether rowcount changes


function registerEvents() {

    $("#frmCustomerDetail").validate({
        errorClass: "red",
        ignore: [],
        lang: "en",
        rules: {
            txtUserName: {
                required: true, 
                alphanumeric: true
            },
            txtFullName: {
                required: true
            },
            txtEmail: {
                required: true,
                email: true
            },
            txtPhoneNumber: {
                required: true,
                number: true
            },
            txtAddress: {
                required: true
            }
        }
    });


    $('#txtBirthDay').datepicker({
        autoclose: true,
        format: 'mm/dd/yyyy'
    });


    $('#txtDateOfBirth').datepicker({
        autoclose: true,
        format: 'mm/dd/yyyy'
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
        resetCustomerDetailForm();
    });


    $("#btnCancel").on("click", function () {
        resetCustomerDetailForm();
    });


    $("body").on("click", ".btn-edit", function (e) {
        e.preventDefault();
        var that = $(this).data("id");

        $.ajax({
            type: "GET",
            url: "/Admin/Customer/GetById",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                $("#CuId").val(res.Id);
                $("#txtUserName").val(res.UserName);
                $("#txtFullName").val(res.FullName);
                $("#txtEmail").val(res.Email);
                $("#txtPhoneNumber").val(res.PhoneNumber);
                $("#txtPassword").val(res.Password);
                $("#txtDateOfBirth").val(res.BirthDay);
                $("#txtAddress").val(res.Address);
                $("#txtCancelBillNumber").val(res.CancelBillNumber);
                $("#txtCreateDate").val(res.DateCreated);
                $("#txtModifyDate").val(res.DateModified);
                $("#ckStatus").prop("checked", res.Status === 1);

                disabledCustomerDetailForm(true);

                $("#modalCustomerDetail").modal("show");

            },
            error: function () {
                homecare.notify("Can not load specified customer", "error");
            }
        });

    });


    $("#btnSave").on("click", function (e) {
        if ($("#frmCustomerDetail").valid()) {
            e.preventDefault();

            var id = $("#CuId").val();
            var username = $("#txtUserName").val();
            var fullname = $("#txtFullName").val();
            var email = $("#txtEmail").val();
            var phonenumber = $("#txtPhoneNumber").val();
            var password = $("#txtPassword").val();
            var birthday = $("#txtDateOfBirth").val();
            var address = $("#txtAddress").val();
            var cancelbillnumber = $("#txtCancelBillNumber").val();
            var datecreated = $("#txtCreateDate").val();
            var datemodified = $("#txtModifyDate").val();
            var status = $("#ckStatus").prop("checked") === true ? 1 : 0;

            $.ajax({
                type: "POST",
                url: "/Admin/Customer/SaveEntity",
                data: {
                    Id: id,
                    UserName: username,
                    FullName: fullname,
                    Email: email,
                    PhoneNumber: phonenumber,
                    Password: password,
                    BirthDay: birthday,
                    Address: address,
                    CancelBillNumber: cancelbillnumber,
                    Status: status,
                    DateCreated: datecreated,
                    DateModified: datemodified
                },
                dataType: "json",
                success: function (res) {

                    if (res.Success === 0) {
                        homecare.notify(res.Message, "error");
                    }
                    if (res.Success === -1) {
                        homecare.notify(res.Message, "error");
                    }
                    if (res.Success === 1) {
                        $("#modalCustomerDetail").modal("hide");
                        resetCustomerDetailForm();
                        homecare.notify(res.Message, "success");
                        loadData();
                    }

                },
                error: function () {
                    homecare.notify("Error Occurred", "error");
                }
            });
        }
        else {
            homecare.notify("Invalid Form", "Error");
        }
    });


    $("body").on("click", ".btn-delete", function (e) {

        e.preventDefault();
        var that = $(this).data("id");

        homecare.confirm("Attention", "Do you wanna delete this Customer ?", function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Customer/Delete",
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


function disabledCustomerDetailForm(disabled) {
    $("#txtPassword").prop("disabled", disabled);
    $("#txtCreateDate").prop("disabled", disabled);
    $("#txtModifyDate").prop("disabled", disabled);
}


function resetCustomerDetailForm() {
    disabledCustomerDetailForm(false);
    $("#CuId").val("");
    $("#txtUserName").val("");
    $("#txtFullName").val("");
    $("#txtEmail").val("");
    $("#txtPhoneNumber").val("");
    $("#txtPassword").val("");
    $("#txtDateOfBirth").val("");
    $("#txtAddress").val("");
    $("#txtCancelBillNumber").val(0);
    $("#txtCreateDate").val("");
    $("#txtModifyDate").val("");
    $("#ckStatus").prop("checked", true);
}


function loadData(isPageChanged) {

    $.ajax({
        type: "GET",
        url: "/Admin/Customer/GetAllPaging",
        data: {
            keyword: $("#txtKeyword").val(),
            birthday: $("#txtBirthDay").val(),
            page: homecare.configs.pageIndex,
            pageSize: homecare.configs.pageSize
        },
        success: function (res) {

            if (res.RowCount === 0) {
                $("#tbl-content").empty();
                homecare.notify("Can not find specified customer", "info");
            }
            else {

                var template = $("#table-template").html();
                var render = "";

                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        username: item.UserName,
                        fullname: item.FullName,
                        email: item.Email,
                        phonenumber: item.PhoneNumber,
                        birthday: item.BirthDay,
                        address: item.Address,
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
            homecare.notify("Cannot load customer data", "error");
        }
    });

}