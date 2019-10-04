//Customer Login Page

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
                    url: '/login/login',
                    success: function (res) {
                        if (res.Success === 1) {
                            homecare.notify("Logged in successfully", "success");
                            window.location.href = "/Home/Index";                            
                        }
                        if (res.Success === 0) {
                            homecare.notify("Incorrect UserName", "error");
                        }
                        if (res.Success === -1) {
                            homecare.notify("Incorrect Password", "error");
                        }
                        if (res.Success === -2) {
                            homecare.notify("Account is locked", "error");
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


        $("#btnRegister").on("click", function (e) {
            e.preventDefault();
            window.location.href = "/Account/Index";
        });

    }

};