// helper management for admin page

var isRowCountChange = null;   // check whether rowcount changes

function registerEvents() {

    $("#frmHelperDetail").validate({
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
            txtPassword: {
                required: true                
            },
            txtIDcard: {
                required: true,
                number: true
            },
            txtDateOfBirth: {
                required: true           
            },
            txtAddress: {
                required: true
            },
            txtCancelBillNumber: {
                required: true,
                number: true
            },
            txtPaymoney: {
                required: true,
                number: true
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


    $("#btnHEDIClose").on("click", function () {
        resetformHelperDetail();
    });


    $("#btnHEDICancel").on("click", function () {
        resetformHelperDetail();
    });


    $("#btnCreate").on("click", function () {
        resetformHelperDetail();
        disableHelperDetailForm(true);
        $("#modalHelperDetail").modal("show");
    });


    $("body").on("click", ".btn-edit", function (e) {
        e.preventDefault();
        var that = $(this).data("id");

        $.ajax({
            type: "GET",
            url: "/Admin/Helper/GetById",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                $("#HeId").val(res.Id);
                $("#txtUserName").val(res.UserName);
                $("#txtFullName").val(res.FullName);
                $("#txtEmail").val(res.Email);
                $("#txtPhoneNumber").val(res.PhoneNumber);
                $("#txtPassword").val(res.Password);
                $("#txtIDcard").val(res.IDcard);
                $("#txtDateOfBirth").val(res.BirthDay);
                $("#txtAddress").val(res.Address);
                $("#txtCancelBillNumber").val(res.CancelBillNumber);
                $("#txtPaymoney").val(res.Paymoney);
                $("#txtCreateDate").val(res.DateCreated);
                $("#txtModifyDate").val(res.DateModified);
                $("#ckStatus").prop("checked", res.Status === 1);

                disableHelperDetailForm(true);

                $("#modalHelperDetail").modal("show");

            },
            error: function () {
                homecare.notify("Can not load specified helper", "error");
            }
        });
    });


    $("#btnHEDISave").on("click", function (e) {
        if ($("#frmHelperDetail").valid()) {
            e.preventDefault();

            var id = $("#HeId").val();
            var username = $("#txtUserName").val();
            var fullname = $("#txtFullName").val();
            var email = $("#txtEmail").val();
            var phonenumber = $("#txtPhoneNumber").val();
            var password = $("#txtPassword").val();
            var Idcard = $("#txtIDcard").val();
            var birthday = $("#txtDateOfBirth").val();
            var address = $("#txtAddress").val();
            var cancelbillnumber = $("#txtCancelBillNumber").val();
            var paymoney = $("#txtPaymoney").val();
            var createddate = $("#txtCreateDate").val();
            var modifieddate = $("#txtModifyDate").val();
            var status = $("#ckStatus").prop("checked") === true ? 1 : 0;

            $.ajax({
                type: "POST",
                url: "/Admin/Helper/SaveEntity",
                data: {
                    Id: id,
                    UserName: username,
                    FullName: fullname,
                    Email: email,
                    PhoneNumber: phonenumber,
                    Password: password,
                    IDcard: Idcard,
                    BirthDay: birthday,
                    Address: address,
                    CancelBillNumber: cancelbillnumber,
                    Paymoney: paymoney,
                    Status: status,
                    DateCreated: createddate,
                    DateModified: modifieddate
                },
                dataType: "json",
                success: function (res) {

                    if (res.Success === 1) {
                        $("#modalHelperDetail").modal("hide");
                        resetformHelperDetail();
                        homecare.notify(res.Message, "success");
                        loadData();
                    }
                    if (res.Success === 0) {
                        homecare.notify(res.Message, "error");
                    }
                    if (res.Success === -1) {
                        homecare.notify(res.Message, "error");
                    }
                    if (res.Success === -2) {
                        homecare.notify(res.Message, "error");
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

        homecare.confirm("Attention", "Do you wanna delete this Helper ?", function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Helper/Delete",
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


function disableHelperDetailForm(disabled) {
    $("#txtCreateDate").prop("disabled", disabled);
    $("#txtModifyDate").prop("disabled", disabled);
}


function resetformHelperDetail() {
    disableHelperDetailForm(false);
    $("#HeId").val("");
    $("#txtUserName").val("");
    $("#txtFullName").val("");
    $("#txtEmail").val("");
    $("#txtPhoneNumber").val("");
    $("#txtPassword").val("");
    $("#txtIDcard").val("");
    $("#txtDateOfBirth").val("");
    $("#txtAddress").val("");
    $("#txtCancelBillNumber").val(0);
    $("#txtPaymoney").val(0);
    $("#txtCreateDate").val("");
    $("#txtModifyDate").val("");
    $("#ckStatus").prop("checked", true);
}


function loadData(isPageChanged) {

    $.ajax({
        type: "GET",
        url: "/Admin/Helper/GetAllPaging",
        data: {
            keyword: $("#txtKeyword").val(),
            birthday: $("#txtBirthDay").val(),
            page: homecare.configs.pageIndex,
            pageSize: homecare.configs.pageSize
        },
        dataType: "json",
        success: function (res) {

            if (res.RowCount === 0) {
                $("#tbl-content").empty();
                homecare.notify("Can not find specified helper", "info");
            }
            else {

                var template = $("#table-template").html();
                var render = "";

                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        fullname: item.FullName,
                        email: item.Email,
                        phonenumber: item.PhoneNumber,
                        idcard: item.IDcard,
                        address: item.Address,
                        paymoney: item.Paymoney,
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
            homecare.notify("Cannot load helper data", "error");
        }
    });

}