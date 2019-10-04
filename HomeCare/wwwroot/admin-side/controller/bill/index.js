// admin bill page

var isRowCountChange = null;   // check whether rowcount changes


function registerEvents() {

    $('#txtWorkDate').datepicker({
        autoclose: true,
        format: 'mm/dd/yyyy'
    });


    $('#txtWorkday').datepicker({
        autoclose: true,
        format: 'mm/dd/yyyy'
    });


    $('#txtStarttime').datetimepicker({
        format: 'LT'
    });


    //validate form before submit
    $('#frmBillDetail').validate({
        errorClass: 'red',
        ignore: [],
        lang: 'en',
        rules: {
            txtWorkplace: {
                required: true
            },
            txtApartmentnumber: {
                required: true
            },
            txtWorkday: {
                required: true
            },
            txtStarttime: {
                required: true
            },
            txtDescription: {
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
    

    //Refresh lại page
    $('#btnReload').on('click', function () {
        loadData();
    });


    $('#btnClose').on('click', function () {
        //$("html").css({ "overflow-y": "scroll" });
        resetformbill();
        $("#btnSave").prop('disabled', false);        
    });


    $('#btnCancel').on('click', function () {
        //$("html").css({ "overflow-y": "scroll" });
        resetformbill();
        $("#btnSave").prop('disabled', false);
    });


    $("body").on("click", ".btn-edit", function (e) {

        e.preventDefault();
        var billId = $(this).data("id");

        $.ajax({
            type: "GET",
            url: "/Admin/Bill/GetById",
            data: {
                id: billId
            },
            dataType: "json",
            success: function (res) {

                var templatebillstatus = null;
                var renderbillstatus = null;

                var templatehelpercheck = null;
                var renderhelpercheck = null;

                var billoption = null;

                if (res.BillStatus === 2 || res.BillStatus === 3
                    || res.BillStatus === 4 || res.BillStatus === 5) {

                    // bỏ dữ liệu vào feild billstatus
                    templatebillstatus = $("#table-template-billstatus").html();
                    renderbillstatus = "";

                    renderbillstatus += Mustache.render(templatebillstatus, {
                        billstatus: homecare.getBillStatus(res.BillStatus)
                    });

                    $("#txtBillStatus").html(renderbillstatus);



                    // bỏ dữ liệu vào field helpercheck
                    templatehelpercheck = $("#table-template-helpercheck").html();
                    renderhelpercheck = "";

                    renderhelpercheck += Mustache.render(templatehelpercheck, {
                        firstcheck: homecare.getHelperCheck(res.Firstcheck),
                        secondcheck: homecare.getHelperCheck(res.Secondcheck),
                        thirdcheck: homecare.getHelperCheck(res.Thirdcheck),
                        cancel: homecare.getHelperCheck(res.Cancel)
                    });

                    $("#txtHelperCheck").html(renderhelpercheck);


                    // bỏ dữ liệu vào bill option
                    billoption = res.Workinghours + ",   " + res.Acreage + " square metre,   " + res.Rooms + " rooms,   " + res.Price + " vnd";

                    $('#BillId').val(res.Id);
                    $('#txtWorkplace').val(res.Workplace);
                    $('#txtApartmentnumber').val(res.Apartmentnumber);
                    $('#txtWorkday').val(res.Workday);
                    $('#txtStarttime').val(res.Starttime);
                    $('#txtBillOptions').val(billoption);
                    $('#txtDescription').val(res.Description);
                    $('#txtCustomerName').val(res.CustomerName);
                    $('#txtCustomerAddress').val(res.CustomerAddress);
                    $('#txtCustomerMobile').val(res.CustomerMobile);
                    $('#txtCustomerEmail').val(res.CustomerEmail);
                    $('#txtPaymentMethod').val(res.PaymentMethodName);
                    $('#txtCreateDate').val(res.DateCreated);
                    $('#txtModifyDate').val(res.DateModified);
                    $('#ckStatus').prop('checked', res.Status === 1);

                    //ẩn toàn bộ form
                    disablebilldetailfeild(true);
                    $('#txtWorkplace').prop('disabled', true);
                    $('#txtApartmentnumber').prop('disabled', true);
                    $('#txtWorkday').prop('disabled', true);
                    $('#txtStarttime').prop('disabled', true);
                    $('#txtDescription').prop('disabled', true);
                    $("#btnSave").prop('disabled', true);


                    $('#modalBillDetail').modal('show');
                }
                else {

                    // bỏ dữ liệu vào feild billstatus
                    templatebillstatus = $("#table-template-billstatus").html();
                    renderbillstatus = "";

                    renderbillstatus += Mustache.render(templatebillstatus, {
                        billstatus: homecare.getBillStatus(res.BillStatus)
                    });

                    $("#txtBillStatus").html(renderbillstatus);



                    // bỏ dữ liệu vào field helpercheck
                    templatehelpercheck = $("#table-template-helpercheck").html();
                    renderhelpercheck = "";

                    renderhelpercheck += Mustache.render(templatehelpercheck, {
                        firstcheck: homecare.getHelperCheck(res.Firstcheck),
                        secondcheck: homecare.getHelperCheck(res.Secondcheck),
                        thirdcheck: homecare.getHelperCheck(res.Thirdcheck),
                        cancel: homecare.getHelperCheck(res.Cancel)
                    });

                    $("#txtHelperCheck").html(renderhelpercheck);


                    // bỏ dữ liệu vào bill option
                    billoption = res.Workinghours + ",   " + res.Acreage + " square metre,   " + res.Rooms + " rooms,   " + res.Price + " vnd";

                    $('#BillId').val(res.Id);
                    $('#txtWorkplace').val(res.Workplace);
                    $('#txtApartmentnumber').val(res.Apartmentnumber);
                    $('#txtWorkday').val(res.Workday);
                    $('#txtStarttime').val(res.Starttime);
                    $('#txtBillOptions').val(billoption);
                    $('#txtDescription').val(res.Description);
                    $('#txtCustomerName').val(res.CustomerName);
                    $('#txtCustomerAddress').val(res.CustomerAddress);
                    $('#txtCustomerMobile').val(res.CustomerMobile);
                    $('#txtCustomerEmail').val(res.CustomerEmail);
                    $('#txtPaymentMethod').val(res.PaymentMethodName);
                    $('#txtCreateDate').val(res.DateCreated);
                    $('#txtModifyDate').val(res.DateModified);
                    $('#ckStatus').prop('checked', res.Status === 1);

                    //ẩn toàn bộ form
                    disablebilldetailfeild(true);

                    $('#modalBillDetail').modal('show');

                }

            },
            error: function () {
                homecare.notify('Can not load specified bill', 'error');
            }
        });

    });


    $("#btnSave").on("click", function (e) {
        if ($('#frmBillDetail').valid()) {
            e.preventDefault();

            var id = $('#BillId').val();
            var workplace = $('#txtWorkplace').val();
            var apartmentnumber = $('#txtApartmentnumber').val();
            var workday = $('#txtWorkday').val();
            var starttime = $('#txtStarttime').val();
            var workinghour = "7h";
            var acreage = 0;
            var room = 0;
            var price = 0;
            var description = $('#txtDescription').val();
            var customerName = $('#txtCustomerName').val();
            var customerAddress = $('#txtCustomerAddress').val();
            var customerMobile = $('#txtCustomerMobile').val();
            var customerEmail = $('#txtCustomerEmail').val();
            var paymentmethod = $('#txtPaymentMethod').val();
            var createddate = $('#txtCreateDate').val();
            var modifieddate = $('#txtModifyDate').val();
            var billstatus = 0;
            var helperid = "doan@gmail.com";
            var firstcheck = true;
            var secondcheck = true;
            var thirdcheck = true;
            var cancel = true;
            var status = $("#ckStatus").prop("checked") === true ? 1 : 0;


            $.ajax({
                type: "POST",
                url: "/Admin/Bill/SaveEntity",
                data: {
                    Id: id,
                    Workplace: workplace,
                    Apartmentnumber: apartmentnumber,
                    Workday: workday,
                    Starttime: starttime,
                    Workinghours: workinghour,
                    Acreage: acreage,
                    Rooms: room,
                    Price: price,
                    Description: description,
                    CustomerName: customerName,
                    CustomerAddress: customerAddress,
                    CustomerMobile: customerMobile,
                    CustomerEmail: customerEmail,
                    PaymentMethodName: paymentmethod,
                    BillStatus: billstatus,
                    Status: status,
                    DateCreated: createddate,
                    DateModified: modifieddate,
                    HelperId: helperid,
                    Firstcheck: firstcheck,
                    Secondcheck: secondcheck,
                    Thirdcheck: thirdcheck,
                    Cancel: cancel
                },
                dataType: "json",
                success: function () {

                    $("#modalBillDetail").modal("hide");
                    resetformbill();

                    homecare.notify('Save successfully', 'success');

                    loadData();

                    //setTimeout(
                    //    function () {
                    //        loadData();
                    //    },
                    //    3000);

                },
                error: function () {
                    $("#modalBillDetail").modal("hide");
                    resetformbill();
                    homecare.notify('Error Occurred', 'error');
                }
            });

        }
        else {
            homecare.notify('invalid form', 'error');
        }
    });


    $("body").on("click", ".btn-delete", function (e) {
        e.preventDefault();
        var that = $(this).data("id");

        homecare.confirm("Attention", "Do you wanna delete this bill ?", function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Bill/DeleteBill",
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


    $("body").on("click", ".btn-helperdetail", function (e) {
        e.preventDefault();
        var that = $(this).data("id");

        $.ajax({
            type: "GET",
            url: "/Admin/Helper/GetHelperforBill",
            data: {
                helperId: that
            },
            dataType: "json",
            success: function (res) {

                var paymoney = res.Paymoney + " vnd";


                // bỏ dữ liệu vào feild helperstatus
                var templatehelperstatus = $("#table-template-helperstatus").html();
                var renderhelperstatus = "";

                renderhelperstatus += Mustache.render(templatehelperstatus, {
                    helperstatus: homecare.getStatus(res.Status)
                });

                $("#txtStatus").html(renderhelperstatus);


                $("#HeId").val(res.Id);
                $("#txtUserName").val(res.UserName);
                $("#txtFullName").val(res.FullName);
                $("#txtEmail").val(res.Email);
                $("#txtPhoneNumber").val(res.PhoneNumber);
                $("#txtIDcard").val(res.IDcard);
                $("#txtBirthDay").val(res.BirthDay);
                $("#txtAddress").val(res.Address);
                $("#txtCancelBillNumber").val(res.CancelBillNumber);
                $("#txtPaymoney").val(paymoney);
                $("#txtDateCreated").val(res.DateCreated);
                $("#txtDateModified").val(res.DateModified);

                disablehelperdetailfeild(true);
                $("#modalHelperDetail").modal("show");

            },
            error: function () {
                homecare.notify("can not load helper's information", "error");
            }
        });
    });


    $("#btnHeDiClose").on("click", function () {
        resetformhelper();
    });

    $("#btnHeDiCancel").on("click", function () {
        resetformhelper();
    });
}


function disablebilldetailfeild(disabled) {

    $('#txtBillOptions').prop('disabled', disabled);
    $('#txtCustomerName').prop('disabled', disabled);
    $('#txtCustomerAddress').prop('disabled', disabled);
    $('#txtCustomerMobile').prop('disabled', disabled);
    $('#txtCustomerEmail').prop('disabled', disabled);
    $('#txtPaymentMethod').prop('disabled', disabled);
    $('#txtCreateDate').prop('disabled', disabled);
    $('#txtModifyDate').prop('disabled', disabled);

}


function resetformbill() {

    $('#txtWorkplace').prop('disabled', false);
    $('#txtApartmentnumber').prop('disabled', false);
    $('#txtWorkday').prop('disabled', false);
    $('#txtStarttime').prop('disabled', false);
    $('#txtDescription').prop('disabled', false);
    disablebilldetailfeild(false);

    $('#BillId').val(0);
    $('#txtWorkplace').val('');
    $('#txtApartmentnumber').val('');
    $('#txtWorkday').val('');
    $('#txtStarttime').val('');
    $('#txtBillOptions').val('');
    $('#txtDescription').val('');
    $('#txtCustomerName').val('');
    $('#txtCustomerAddress').val('');
    $('#txtCustomerMobile').val('');
    $('#txtCustomerEmail').val('');
    $('#txtPaymentMethod').val('');
    $('#txtCreateDate').val('');
    $('#txtModifyDate').val('');
    $('#txtBillStatus').empty();
    $('#txtHelperCheck').empty();
    $('#ckStatus').prop('checked', true);

}


function disablehelperdetailfeild(disabled) {

    $("#txtUserName").prop("disabled", disabled);
    $("#txtFullName").prop("disabled", disabled);
    $("#txtEmail").prop("disabled", disabled);
    $("#txtPhoneNumber").prop("disabled", disabled);
    $("#txtIDcard").prop("disabled", disabled);
    $("#txtBirthDay").prop("disabled", disabled);
    $("#txtAddress").prop("disabled", disabled);
    $("#txtCancelBillNumber").prop("disabled", disabled);
    $("#txtPaymoney").prop("disabled", disabled);
    $("#txtDateCreated").prop("disabled", disabled);
    $("#txtDateModified").prop("disabled", disabled);

}


function resetformhelper() {

    disablehelperdetailfeild(false);
    $("#HeId").val('');
    $("#txtUserName").val('');
    $("#txtFullName").val('');
    $("#txtEmail").val('');
    $("#txtPhoneNumber").val('');
    $("#txtIDcard").val('');
    $("#txtBirthDay").val('');
    $("#txtAddress").val('');
    $("#txtCancelBillNumber").val(0);
    $("#txtPaymoney").val('');
    $("#txtDateCreated").val('');
    $("#txtDateModified").val('');
    $('#txtStatus').empty();

}


function loadData(isPageChanged) {

    $.ajax({
        type: "GET",
        url: "/Admin/Bill/GetAllPaging",
        data: {
            keyword: $("#txtKeyword").val(),
            workdate: $("#txtWorkDate").val(),          
            page: homecare.configs.pageIndex,
            pageSize: homecare.configs.pageSize
        },
        dataType: "json",
        success: function (res) {

            if (res.RowCount === 0) {
                $("#tbl-content").empty();
                homecare.notify("Can not find specified bill","info");
            }
            else {

                var template = $("#table-template").html();
                var render = "";

                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        workplace: item.Workplace,
                        apartmentnumber: item.Apartmentnumber,
                        workday: item.Workday,
                        starttime: item.Starttime,
                        billstatus: homecare.getBillStatus(item.BillStatus),
                        status: homecare.getStatus(item.Status),
                        helperId: item.HelperId
                    });                   
                });

                if (render !== "") {
                    $("#tbl-content").html(render);
                }
                

                $("#tbl-content > tr").each(function () {                                                             

                    var billstatus = $(this).find(".bill-status").html();

                    // if BillStatus is New, Admin can edit and delete the bill
                    if (billstatus === '<span class="badge bg-blue">New</span>') {
                        $(this).find(".btn-helperdetail").prop("disabled", true);
                        $(this).find(".btn-edit").prop("disabled", false);
                        $(this).find(".btn-delete").prop("disabled", false);
                    }

                    // if BillStatus is Inprocess, Admin can only view helperdetail and billdetail
                    if (billstatus === '<span class="badge bg-yellow">Inprocess</span>') {
                        $(this).find(".btn-helperdetail").prop("disabled", false);
                        $(this).find(".btn-edit").prop("disabled", false);
                        $(this).find(".btn-delete").prop("disabled", true);
                    }


                    //if BillStatus is Canceled, Admin can view bill and helperdetail 
                    //in case, there is a helper accepted the bill 
                    if (billstatus === '<span class="badge bg-red">Cancelled</span>') {  

                        var heId = $(this).find(".btn-helperdetail").data('id');

                        if (heId === "") {
                            $(this).find(".btn-helperdetail").prop("disabled", true);
                        }
                        else {
                            $(this).find(".btn-helperdetail").prop("disabled", false);
                        }
                        $(this).find(".btn-edit").prop("disabled", false);
                        $(this).find(".btn-delete").prop("disabled", false);

                    }

                    // if BillStatus is Incomplete, Admin can view helper detail, view bill and delete bill
                    if (billstatus === '<span class="badge bg-orange">Incomplete</span>') {
                        $(this).find(".btn-helperdetail").prop("disabled", false);
                        $(this).find(".btn-edit").prop("disabled", false);
                        $(this).find(".btn-delete").prop("disabled", false);
                    }


                    // if BillStatus is Completed, Admin can view helper detail, view bill and delete bill
                    if (billstatus === '<span class="badge bg-green">Completed</span>') {
                        $(this).find(".btn-helperdetail").prop("disabled", false);
                        $(this).find(".btn-edit").prop("disabled", false);
                        $(this).find(".btn-delete").prop("disabled", false);
                    }
                });

                
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
            homecare.notify("Cannot load bill data", "error");
        }
    });

}