//Helper Bill Page


var checknumber = 0;  //Biến để xác định số lần check


function hpcheck() {

    $("#frmMaintainance").validate({
        errorClass: 'red',
        ignore: [],
        lang: 'en',
        rules: {            
            txtPassword: {
                required: true
            }
        }
    });

    // mặc định ẩn các nút để check
    $('#txtPassword').prop('disabled', true);
    $('#btnCancelBill').prop('disabled', true);
    $('#btnSubmit').prop('disabled', true);


    $('#btnAccept').on('click', function (e) {

        e.preventDefault();
        var that = $('#BillId').val();

        $.ajax({
            type: "POST",
            url: "/Helper/Bill/AcceptBill",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                homecare.notify('You have accepted the bill', 'success');

                $('#btnCancel').prop('disabled', true);
                $('#btnCheck').prop('disabled', true);
                $('#btnAccept').prop('disabled', true);                

                $('#txtPassword').prop('disabled', false);
                $('#btnCancelBill').prop('disabled', false);
                $('#btnSubmit').prop('disabled', false);

            },
            error: function () {
                homecare.notify('Error occurred', 'error');
            }
        });

    });



    $('#btnSubmit').on('click', function (e) {

        if ($('#frmMaintainance').valid()) {

            e.preventDefault();
            var that = $('#BillId').val();
            var pass = $('#txtPassword').val();

            $.ajax({
                type: "POST",
                url: "/Helper/Bill/SingleCheck",
                data: {
                    Id: that,
                    Password: pass,
                    HPCheck: true
                },
                dataType: "json",
                success: function (res) {

                    if (res.Success === 0) {
                        homecare.notify(res.Message, 'error');
                    }
                    if (res.Success === -1) {
                        homecare.notify(res.Message, 'error');
                    }
                    if (res.Success === -2) {
                        homecare.notify("Third checking successful", 'success');
                        homecare.notify(res.Message, 'error');

                        $('#modalBillDetail').modal('hide');
                        $("html").css({ "overflow-y": "scroll" });
                        resetFormMaintainance();
                        $('#txtPassword').val('');

                        $('#btnCancel').prop('disabled', false);
                        $('#btnCheck').prop('disabled', false);
                        $('#btnAccept').prop('disabled', false);

                        $('#txtPassword').prop('disabled', true);
                        $('#btnCancelBill').prop('disabled', true);
                        $('#btnSubmit').prop('disabled', true);

                        setTimeout(
                            function () {
                                location.reload();
                            },
                            5000);
                    }
                    if (res.Success === 1) {
                        homecare.notify(res.Message, 'success');
                    }
                    if (res.Success === 2) {
                        homecare.notify(res.Message, 'success');
                    }
                    if (res.Success === 3) {
                        homecare.notify("Third checking successful", 'success');
                        homecare.notify(res.Message, 'success');

                        $('#modalBillDetail').modal('hide');
                        $("html").css({ "overflow-y": "scroll" });
                        resetFormMaintainance();
                        $('#txtPassword').val('');

                        $('#btnCancel').prop('disabled', false);
                        $('#btnCheck').prop('disabled', false);
                        $('#btnAccept').prop('disabled', false);

                        $('#txtPassword').prop('disabled', true);
                        $('#btnCancelBill').prop('disabled', true);
                        $('#btnSubmit').prop('disabled', true);

                        setTimeout(
                            function () {
                                location.reload();
                            },
                            5000);
                    }

                },
                error: function (res) {
                    homecare.notify('Error occurred', 'error');
                }
            });

        }
        else {
            homecare.notify('Password required', 'error');
        }

    });


    $('#btnCancelBill').on('click', function (e) {

        if ($('#frmMaintainance').valid()) {

            e.preventDefault();
            var that = $('#BillId').val();            // Id của bill
            var pass = $('#txtPassword').val();       // Password của helper
            

            $.ajax({
                type: "GET",
                url: "/Helper/Notification/GetNotification",
                data: {
                    Password: pass
                },
                dataType: "json",
                success: function (res) {

                    if (res.Success === 0) {
                        homecare.notify(res.Message, 'error');
                    }

                    if (res.Success === 1) {

                        e.preventDefault();

                        homecare.confirm(res.Data.Title, res.Data.Content, function () {
                            $.ajax({
                                type: "POST",
                                url: "/Helper/Bill/CancelBill",
                                data: {
                                    id: that
                                },
                                dataType: "json",
                                success: function (res) {

                                    $('#modalBillDetail').modal('hide');
                                    $("html").css({ "overflow-y": "scroll" });
                                    resetFormMaintainance();
                                    $('#txtPassword').val('');

                                    $('#btnCancel').prop('disabled', false);
                                    $('#btnCheck').prop('disabled', false);
                                    $('#btnAccept').prop('disabled', false);

                                    $('#txtPassword').prop('disabled', true);
                                    $('#btnCancelBill').prop('disabled', true);
                                    $('#btnSubmit').prop('disabled', true);

                                    homecare.notify(res.Message, 'success');

                                    setTimeout(
                                        function () {
                                            location.reload();
                                        },
                                        4000);

                                },
                                error: function () {
                                    homecare.notify('Has an error in deleting process', 'error');
                                }
                            });
                        });
                    }
                    
                },
                error: function () {
                    homecare.notify('can not load notification for helper', 'error');
                }
            });                      
        }
        else {
            homecare.notify('Password required', 'error');
        }             

    });

}


function registerEvents() {


    // Đóng modal, hiện lại thanh cuộn dọc
    //$('#btnClose').on('click', function () {
    //    $("html").css({ "overflow-y": "scroll" });
    //    resetFormMaintainance();
    //});


    // Đóng modal, hiện lại thanh cuộn dọc
    $('#btnCancel').on('click', function () {
        $("html").css({ "overflow-y": "scroll" });   
        resetFormMaintainance();
    });


    //Refresh lại page
    $('#btnReload').on('click', function () {
        location.reload();
    });

    $('body').on('click', '.btn-detail-bill', function (e) {

        e.preventDefault();
        var that = $(this).data('id');

        $.ajax({
            type: "GET",
            url: "/Helper/Bill/GetById",
            data: {
                id: that                
            },
            dataType: "json",
            success: function (res) {                

                var billoption = res.Workinghours + ",   " + res.Acreage + " square metre,   " + res.Rooms + " rooms,   " + res.Price + " vnd";

                $('#BillId').val(res.Id);
                $('#txtWorkplace').val(res.Workplace);
                $('#txtApartmentnumber').val(res.Apartmentnumber);
                $('#txtWorkday').val(res.Workday);
                $('#txtStarttime').val(res.Starttime);

                $('#txtBillOption').val(billoption);                

                $('#txtDescription').val(res.Description);
                $('#txtCustomerName').val(res.CustomerName);
                $('#txtCustomerAddress').val(res.CustomerAddress);
                $('#txtCustomerMobile').val(res.CustomerMobile);
                $('#txtCustomerEmail').val(res.CustomerEmail);
                $('#txtPaymentmethod').val(res.PaymentMethodName);

                disableField(true);      

                if (res.AcceptBill === true) {
                    $('#btnAccept').prop('disabled', false);     // cho phép nhận bill
                }
                else {
                    $('#btnAccept').prop('disabled', true);      // không cho phép nhận bill
                }

                $("html").css({ "overflow-y": "hidden" });
                $('#modalBillDetail').modal('show');
            },
            error: function (e) {
                homecare.notify('Can not find specified bill', 'error');
            }
        });
    });


    $('body').on('click', '#btnCheck', function (e) {

        e.preventDefault();
        var that = $('#BillId').val();

        $.ajax({
            type: "GET",
            url: "/Helper/Bill/GetBillStatus",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                if (res.Success === 0) {                    
                    homecare.notify('The Bill has just been created', 'info');
                }
                if (res.Success === 1) {
                    $('#modalBillDetail').modal('hide');
                    $("html").css({ "overflow-y": "scroll" });
                    resetFormMaintainance();
                    
                    homecare.notify('Customer is Editing the bill', 'info');

                    setTimeout(
                        function () {
                            location.reload();
                        },
                        5000);
                }
                if (res.Success === 2) {
                    $('#modalBillDetail').modal('hide');
                    $("html").css({ "overflow-y": "scroll" });
                    resetFormMaintainance();

                    homecare.notify('There is a helper who has accepted the bill', 'info');

                    setTimeout(
                        function () {
                            location.reload();
                        },
                        5000);
                }

            },
            error: function () {
                homecare.notify('Error Occurred', 'error');
            }
        });

    });


}


// Reset Form
function resetFormMaintainance() {

    disableField(false);

    $('#BillId').val(0);
    $('#txtWorkplace').val('');
    $('#txtApartmentnumber').val('');
    $('#txtWorkday').val('');
    $('#txtStarttime').val('');

    $('#txtBillOption').val('');    

    $('#txtDescription').val('');
    $('#txtCustomerName').val('');
    $('#txtCustomerAddress').val('');
    $('#txtCustomerMobile').val('');
    $('#txtCustomerEmail').val('');
    $('#txtPaymentmethod').val('');

}


// ẩn form không cho chỉnh sửa 
function disableField(disabled) {
    $('#txtWorkplace').prop('disabled', disabled);
    $('#txtApartmentnumber').prop('disabled', disabled);
    $('#txtWorkday').prop('disabled', disabled);
    $('#txtStarttime').prop('disabled', disabled);

    $('#txtBillOption').prop('disabled', disabled);    

    $('#txtDescription').prop('disabled', disabled);
    $('#txtCustomerName').prop('disabled', disabled);
    $('#txtCustomerAddress').prop('disabled', disabled);
    $('#txtCustomerMobile').prop('disabled', disabled);
    $('#txtCustomerEmail').prop('disabled', disabled);
    $('#txtPaymentmethod').prop('disabled', disabled);
} 


