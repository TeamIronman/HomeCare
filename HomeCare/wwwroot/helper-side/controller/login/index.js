﻿//Helper Login Page

var loginController = {

    login: function () {

        $("#frmLogin").validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtUserName: {
                    required: true,
                    alphanumeric: true
                },
                txtPassword: {
                    required: true
                }
            }
        });

        $("#btnLogin").on("click", function (e) {
            if ($("#frmLogin").valid()) {
                e.preventDefault();
                var username = $("#txtUserName").val();
                var password = $("#txtPassword").val();

                $.ajax({
                    type: 'POST',
                    data: {
                        UserName: username,
                        Password: password
                    },
                    dataType: 'json',
                    url: '/Helper/Login/Login',
                    success: function (res) {
                        if (res.Success === 1) {
                            homecare.notify(res.Message, "success");
                            window.location.href = "/Helper/Home/Index";                            
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
                    error: function (res) {
                        homecare.notify("Error occurred", "error");
                    }
                });
            }
            else {
                homecare.notify('invalid form', 'error');
            }
        });
       
    }

};