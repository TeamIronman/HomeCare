//Customer Bill page

var billid = null; // Bill's id

//event handle when Admin click on 'add', 'edit' or 'delete' button
function registerEvents() {

    $('#txtWorkday').datepicker({
        autoclose: true,
        format: 'mm/dd/yyyy'
    });

    $('#txtStarttime').datetimepicker({
        format: 'LT'
    });

    //validate form before submit
    $('#frmMaintainance').validate({
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
            txtBillOptions: {
                required: true
            },
            txtNuOfHe: {
                required: true
            },
            txtDescription: {
                required: true
            },
            txtCustomerName: {
                required: true
            },
            txtCustomerAddress: {
                required: true
            },
            txtCustomerMobile: {
                required: true,
                number: true,
                maxlength: 10
            },
            txtCustomerEmail: {
                required: true,
                email: true
            },
            txtPaymentMethod: {
                required: true
            }
        }
    });
    

    $('#btnCreate').off('click').on('click', function () {
        resetFormMaintainance();
        $("html").css({ "overflow-y": "hidden" });
        $('#modalAddEdit').modal('show');       
    });


    //Refresh lại page
    $('#btnReload').on('click', function () {
        location.reload();
    });


    $('#btnClose').on('click', function () {
        $("html").css({ "overflow-y": "scroll" });
        resetFormMaintainance();
        $("#btnSave").prop('disabled', false);


        // chuyen billstatus lai thanh new neu customer bam edit button nhung khong save ma bam close
        if (billid !== null) {

            $.ajax({
                type: "GET",
                url: "/Bill/ChangeBillStatus",
                data: {
                    id: billid
                },
                dataType: "json",
                success: function () {
                    billid = null;
                },
                error: function () {
                }
            });

        }
    });


    $('#btnCancel').on('click', function () {
        $("html").css({ "overflow-y": "scroll" });
        resetFormMaintainance();
        $("#btnSave").prop('disabled', false);

        // chuyen billstatus lai thanh new neu customer bam edit button nhung khong save ma bam close
        if (billid !== null) {

            $.ajax({
                type: "GET",
                url: "/Bill/ChangeBillStatus",
                data: {
                    id: billid
                },
                dataType: "json",
                success: function () {
                    billid = null;
                },
                error: function () {
                }
            });

        }

    });


    $('body').on('click', '.btn-edit', function (e) {
        
        e.preventDefault();
        var that = $(this).data('id');
        billid = $(this).data('id');         // billid được post lên server để thay đổi trạng thái bill từ isChanging về New nếu người dùng chọn Edit nhưng lại nhấn close

        $.ajax({
            type: "GET",
            url: "/Bill/GetById",
            data: {
                id: that                
            },
            dataType: "json",
            success: function (res) {

                $('#BillId').val(res.Id);
                $('#txtWorkplace').val(res.Workplace);
                $('#txtApartmentnumber').val(res.Apartmentnumber);
                $('#txtWorkday').val(res.Workday);
                $('#txtStarttime').val(res.Starttime);
                
                $('#txtDescription').val(res.Description);
                $('#txtCustomerName').val(res.CustomerName);
                $('#txtCustomerAddress').val(res.CustomerAddress);
                $('#txtCustomerMobile').val(res.CustomerMobile);
                $('#txtCustomerEmail').val(res.CustomerEmail);

                disableField(true);

                $("html").css({ "overflow-y": "hidden" });
                $('#modalAddEdit').modal('show');   
            },
            error: function (e) {
                homecare.notify('Can not find specified bill', 'error');
            }
        });
    });


    $('body').on('click', '.btn-delete', function (e) {

        var that = $(this).data('id');

        $.ajax({
            type: "GET",
            url: "/Notification/GetNotification",
            dataType: "json",
            success: function (res) {

                e.preventDefault();
                
                homecare.confirm(res.Title, res.Content, function () {
                    $.ajax({
                        type: "POST",
                        url: "/Bill/Delete",
                        data: {
                            id: that
                        },
                        dataType: "json",
                        success: function () {

                            location.reload();

                            homecare.notify('Successfully deleted', 'success');
                        },
                        error: function () {
                            homecare.notify('Has an error in deleting process', 'error');
                        }
                    });
                });

            },
            error: function () {
                homecare.notify('can not load notification', 'error');
            }
        });        

    });


    $('#btnSave').on('click', function (e) {
        if ($('#frmMaintainance').valid()) {
            e.preventDefault();

            var id = $('#BillId').val();
            var workplace = $('#txtWorkplace').val();
            var apartmentnumber = $('#txtApartmentnumber').val();
            var workday = $('#txtWorkday').val();
            var starttime = $('#txtStarttime').val();

            var billoption = $('#txtBillOptions').val();
            var helpernumber = $('#txtNuOfHe').val();
            
            var description = $('#txtDescription').val();
            var customerName = $('#txtCustomerName').val();
            var customerAddress = $('#txtCustomerAddress').val();
            var customerMobile = $('#txtCustomerMobile').val();
            var customerEmail = $('#txtCustomerEmail').val();

            var paymentmethod = $('#txtPaymentMethod').val();


            //dùng cho trường hợp sửa bill
            if (billoption === null) {
                billoption = 0;
            }
            if (helpernumber === null) {
                helpernumber = 0;
            }
            if (paymentmethod === null) {
                paymentmethod = 0;
            }


            $.ajax({
                type: "POST",
                url: "/Bill/SaveEntity",
                data: {
                    Id: id,
                    Workplace: workplace,
                    Apartmentnumber: apartmentnumber,
                    Workday: workday,
                    Starttime: starttime,
                    
                    Description: description,
                    CustomerName: customerName,
                    CustomerAddress: customerAddress,
                    CustomerMobile: customerMobile,
                    CustomerEmail: customerEmail,

                    BillOptionId: billoption,
                    PaymentMethodId: paymentmethod,

                    henumberId: helpernumber
                },
                dataType: "json",
                success: function (response) {

                    if (response.Success === 0) {
                        homecare.notify(response.Message, 'error');
                    }
                    if (response.Success === -1) {
                        homecare.notify(response.Message, 'error');
                    }
                    if (response.Success === -2) {
                        homecare.notify(response.Message, 'error');
                    }
                    if (response.Success === -3) {
                        homecare.notify(response.Message, 'error');
                    }
                    if (response.Success === 1) {

                        $('#modalAddEdit').modal('hide');
                        resetFormMaintainance();

                        location.reload();

                        homecare.notify(response.Message, 'success');
                        
                    }
                                       
                },
                error: function () {
                    $('#modalAddEdit').modal('hide');
                    $("html").css({ "overflow-y": "scroll" });
                    resetFormMaintainance();
                    homecare.notify('error occurred', 'error');
                }
            });
        }
        else {
            homecare.notify('invalid form', 'error');
        }
    });


    $('.btn-check-billstatus').on('click', function (e) {

        e.preventDefault();
        var that = $(this).data('id');

        $.ajax({
            type: "GET",
            url: "/Bill/GetBillStatus",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                if (res.Success === 0) {
                    homecare.notify('there is no helper has accepted the bill yet', 'info');       
                }
                if (res.Success === 2) {
                    location.reload();
                    homecare.notify('There is a helper who has accepted the bill', 'info');
                }

            },
            error: function () {
                homecare.notify('Error Occurred', 'error');
            }
        });
    });


    $('body').on('click', '.btn-detail-bill', function (e) {

        e.preventDefault();
        var that = $(this).data('id');

        $.ajax({
            type: "GET",
            url: "/Bill/GetBilltoView",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                var billoption = res.Workinghours + ",   " + res.Acreage + " square metre,   " + res.Rooms + " rooms,   " + res.Price + " vnd";

                $('#BiDeId').val(res.Id);
                $('#txtBIDWorkplace').val(res.Workplace);
                $('#txtBIDApartmentnumber').val(res.Apartmentnumber);
                $('#txtBIDWorkday').val(res.Workday);
                $('#txtBIDStarttime').val(res.Starttime);

                $('#txtBIDBillOptions').val(billoption);
                
                $('#txtBIDDescription').val(res.Description);
                $('#txtBIDCustomerName').val(res.CustomerName);
                $('#txtBIDCustomerAddress').val(res.CustomerAddress);
                $('#txtBIDCustomerMobile').val(res.CustomerMobile);
                $('#txtBIDCustomerEmail').val(res.CustomerEmail);
                $('#txtBIDPaymentMethod').val(res.PaymentMethodName);

                disablebilldetailfeild(true);
                

                $("html").css({ "overflow-y": "hidden" });
                $('#modalBillDetail').modal('show');
            },
            error: function (e) {
                homecare.notify('Can not find specified bill', 'error');
            }
        });
    });


    $("#btnBIDCancel").on("click", function () {
        $("html").css({ "overflow-y": "scroll" });
        resetFormbilldetail();
    });


    $("#btnBIDClose").on("click", function () {
        $("html").css({ "overflow-y": "scroll" });
        resetFormbilldetail();
    });
}


function helperdetail() {

    $('body').on('click', '.btn-detail-helper', function (e) {

        e.preventDefault();
        var that = $(this).data('id');

        $.ajax({
            type: "GET",
            url: "/Helper/GetById",
            data: {
                id: that
            },
            dataType: "json",
            success: function (res) {

                $('#HeId').val(res.Id);
                $('#txtHDFullName').val(res.FullName);
                $('#txtHDEmail').val(res.Email);
                $('#txtHDPhoneNumber').val(res.PhoneNumber);
                $('#txtHDBirthDay').val(res.BirthDay);
                $('#txtHDAddress').val(res.Address);

                disableHelperField(true);

                $("html").css({ "overflow-y": "hidden" });
                $('#modalHelperDetail').modal('show');
            },
            error: function (res) {
                homecare.notify('Can not find specified helper', 'error');
            }
        });

    });


    $('#btnHDCancel').on('click', function () {
        $("html").css({ "overflow-y": "scroll" });
        resetHelperForm();
    });


    $('#btnHDClose').on('click', function () {
        $("html").css({ "overflow-y": "scroll" });
        resetHelperForm();
    });

}


function loadbilloption() {

    $.ajax({
        type: "GET",
        url: "/Bill/GetBillOption",
        dataType: "json",
        success: function (res) {

            var template = $('#table-template-billoption').html();

            var render = "<option value='0' style='font-weight: bold;'>Select bill options</option>";

            $.each(res, function (i, item) {
                render += Mustache.render(template, {
                    OptionId: item.Id,
                    workinghours: item.Workinghours,
                    acreage: item.Acreage,
                    rooms: item.Rooms,
                    price: item.Price 
                });
            });

            $('#txtBillOptions').html(render);
        },
        error: function () {
            homecare.notify('Can not load Bill options', 'error');
        }
    });

}


function loadhelpernumber() {

    $("#txtBillOptions").on("change", function () {

        var optionid = $("#txtBillOptions").val();

        $.ajax({
            type: "GET",
            url: "/Helper/GetHelperNumber",
            data: {
                id: optionid
            },
            dataType: "json",
            success: function (res) {

                var template = $('#table-template-helpernumber').html();

                var render = "<option value='0' style='font-weight: bold;'>Select number of helpers</option>";

                $.each(res, function (i, item) {
                    render += Mustache.render(template, {
                        helpernumberId: item.Id,
                        amount: item.Amount
                    });
                });

                $('#txtNuOfHe').html(render);
            },
            error: function () {
                homecare.notify('Can not load helper number', 'error');
            }
        });

    });

}


function loadpaymentmethod() {

    $.ajax({
        type: "GET",
        url: "/Payment/GetPaymentMethod",
        dataType: "json",
        success: function (res) {

            var template = $('#table-template-paymentmethod').html();

            var render = "<option value='0' style='font-weight: bold;'>Select payment method</option>";


            $.each(res, function (i, item) {
                render += Mustache.render(template, {
                    paymentmethodId: item.Id,
                    name: item.Name
                });
            });


            $('#txtPaymentMethod').html(render);
        },
        error: function () {
            homecare.notify('Can not load payment methods', 'error');
        }
    });

}


// Reset Form add, edit bill
function resetFormMaintainance() {

    disableField(false);

    $('#BillId').val(0);
    $('#txtWorkplace').val('');
    $('#txtApartmentnumber').val('');
    $('#txtWorkday').val('');
    $('#txtStarttime').val('');    

    $('#txtDescription').val('');
    $('#txtCustomerName').val('');
    $('#txtCustomerAddress').val('');
    $('#txtCustomerMobile').val('');
    $('#txtCustomerEmail').val('');    

}


// ẩn form edit bill không cho chỉnh sửa 
function disableField(disabled) {
    $('#txtWorkplace').prop('disabled', disabled);
    $('#txtApartmentnumber').prop('disabled', disabled);   

    $('#txtBillOptions').prop('disabled', disabled);   
    $('#txtNuOfHe').prop('disabled', disabled);   

    $('#txtDescription').prop('disabled', disabled);
    $('#txtCustomerName').prop('disabled', disabled);
    $('#txtCustomerAddress').prop('disabled', disabled);
    $('#txtCustomerMobile').prop('disabled', disabled);
    $('#txtCustomerEmail').prop('disabled', disabled);

    $('#txtPaymentMethod').prop('disabled', disabled);
} 


// reset form chi tiết bill
function resetFormbilldetail() {

    disablebilldetailfeild(false);

    $('#BiDeId').val(0);
    $('#txtBIDWorkplace').val('');
    $('#txtBIDApartmentnumber').val('');
    $('#txtBIDWorkday').val('');
    $('#txtBIDStarttime').val('');
    $('#txtBIDBillOptions').val('');
    $('#txtBIDDescription').val('');
    $('#txtBIDCustomerName').val('');
    $('#txtBIDCustomerAddress').val('');
    $('#txtBIDCustomerMobile').val('');
    $('#txtBIDCustomerEmail').val('');
    $('#txtBIDPaymentMethod').val('');

}


// ẩn form chi tiết bill không cho chỉnh sửa
function disablebilldetailfeild(disabled) {

    $('#txtBIDWorkplace').prop('disabled', disabled);
    $('#txtBIDApartmentnumber').prop('disabled', disabled);
    $('#txtBIDWorkday').prop('disabled', disabled);
    $('#txtBIDStarttime').prop('disabled', disabled);
    $('#txtBIDBillOptions').prop('disabled', disabled);
    $('#txtBIDDescription').prop('disabled', disabled);
    $('#txtBIDCustomerName').prop('disabled', disabled);
    $('#txtBIDCustomerAddress').prop('disabled', disabled);
    $('#txtBIDCustomerMobile').prop('disabled', disabled);
    $('#txtBIDCustomerEmail').prop('disabled', disabled);
    $('#txtBIDPaymentMethod').prop('disabled', disabled);

}


// reset form thông tin helper
function resetHelperForm() {

    disableHelperField(false);
    $('#HeId').val('');
    $('#txtHDFullName').val('');
    $('#txtHDEmail').val('');
    $('#txtHDPhoneNumber').val('');
    $('#txtHDBirthDay').val('');
    $('#txtHDAddress').val('');

}



// ẩn form Helper không cho chỉnh sửa 
function disableHelperField(disabled) {
    $('#txtHDFullName').prop('disabled', disabled);
    $('#txtHDEmail').prop('disabled', disabled);
    $('#txtHDPhoneNumber').prop('disabled', disabled);
    $('#txtHDBirthDay').prop('disabled', disabled);
    $('#txtHDAddress').prop('disabled', disabled);
}