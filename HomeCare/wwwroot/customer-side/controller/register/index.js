//Customer Register Page

var registerController = {

    register: function () {

        $("#frmLogin").validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtUserName: {
                    required: true,
                    alphanumeric: true
                },   
                txtFullName: {
                    required: true
                },                 
                txtPassword: {
                    required: true,
                    minlength: 6
                },
                txtPasswordComfirm: {
                    required: true,
                    equalTo: "#txtPassword"
                },
                txtEmail: {
                    required: true,
                    email: true
                },
                txtPhoneNumber: {
                    required: true,
                    number: true,
                    maxlength: 10
                },
                txtAddress: {
                    required: true                  
                }
            }
        });

        $("#btnRegister").on("click", function (e) {
            if ($("#frmLogin").valid()) {

                e.preventDefault();
                var username = $("#txtUserName").val();
                var fullname = $("#txtFullName").val();        
                var password = $("#txtPassword").val();
                var email = $("#txtEmail").val();
                var phonenumber = $("#txtPhoneNumber").val();
                var address = $("#txtAddress").val();
                

                $.ajax({
                    type: 'POST',
                    data: {
                        UserName: username,
                        FullName: fullname,
                        Email: email,
                        PhoneNumber: phonenumber,
                        Password: password,
                        Address: address
                    },
                    dataType: 'json',
                    url: '/Account/Register',
                    success: function (res) {
                        if (res.Success === 1) {                            
                            homecare.notify("Successfully Registered", "success");
                            window.location.href = "/Home/Index";
                        }
                        if (res.Success === 0) {
                            homecare.notify("UserName or Email already exits", "error");
                        }                          
                    },
                    error: function (res) {
                        homecare.notify("Error occurred", "error");
                    }
                });
            }
            else {
                homecare.notify('invalid form', 'error');
            }
        });


        $("#btnLogin").on("click", function (e) {
            e.preventDefault();
            window.location.href = "/Login/Index";
        });

    }

};