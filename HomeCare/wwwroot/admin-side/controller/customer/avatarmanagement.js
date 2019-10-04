// admin manage helper's images

var data = null; // empty form data

function manageimages() {

    $("body").on("click", ".btn-images", function (e) {
        e.preventDefault();
        var that = $(this).data("id");
        $("#CustomerId").val(that);
        loadImages();
        $("#modalCustomerAvatar").modal("show");
    });


    $("#btnCUAClose").on("click", function () {
        resetCustomerAvatarForm();
    });


    $("#btnCUACancel").on("click", function () {
        resetCustomerAvatarForm();
    });


    $("#txtChoseImages").on("change", function () {

        // FileList Javascript API and FormData to submit form
        var fileUpload = $(this).get(0);
        var files = fileUpload.files;
        if (files.length > 0) {
            data = new FormData();
            $("#txtImagesChosen").empty();

            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);

                var reader = new FileReader();

                reader.onload = function (event) {
                    $("#txtImagesChosen").append('<div class="col-sm-4"><img class="img-responsive" width="300" height = "300" src = "' + event.target.result + '" alt = "helperimage" ></div >');
                };

                reader.readAsDataURL(files[i]);
            }
            
            data.append("CustomerId", $("#CustomerId").val());
        }
        else {
            homecare.notify('Error Occurred', 'error');
        }

    });


    $("#btnCUASave").on("click", function () {
        if (data === null) {
            homecare.notify('Please select a new image', 'info');
        }
        else {
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadCustomerAvatar",
                contentType: false,
                processData: false,
                data: data,
                success: function () {
                    $("#modalCustomerAvatar").modal("hide");
                    resetCustomerAvatarForm();
                    homecare.notify("Saving Images Successfull", "success");
                },
                error: function () {
                    homecare.notify("There is an error in saving images process", "error");
                }
            });
        }
    });
}


function loadImages() {

    $.ajax({
        type: "GET",
        url: "/Admin/Upload/GetCuAvatarById",
        data: {
            customerId: $("#CustomerId").val()
        },
        dataType: "json",
        success: function (res) {

            if (res.Resultstring !== null) {
                var render = "";

                render += '<div class="col-sm-4"><img class="img-responsive" width="300" height = "300" src = "' + res.Resultstring + '" alt = "customeravatar" ><br/></div >';

                $("#txtImagesChosen").html(render);
            }
            
        },
        error: function () {
            homecare.notify("Can not load Images", "error");
        }
    });

}


function resetCustomerAvatarForm() {
    $("#CustomerId").val("");
    $("#txtImagesChosen").empty();
    $("#txtChoseImages").val("");
    data = null;
}