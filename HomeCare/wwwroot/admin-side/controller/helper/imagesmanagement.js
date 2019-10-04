// admin manage helper's images

var data = null; // empty form data

function manageimages() {

    $("body").on("click", ".btn-images", function (e) {
        e.preventDefault();
        var that = $(this).data("id");
        $("#HelperId").val(that);
        loadImages();
        $("#modalHelperImages").modal("show");
    });


    $("#btnHEIClose").on("click", function () {
        resetHelperImagesForm();
    });

    $("#btnHEICancel").on("click", function () {
        resetHelperImagesForm();
    });


    $("#txtChoseImages").on("change", function () {

        // FileList Javascript API and FormData to submit form
        var fileUpload = $(this).get(0);
        var files = fileUpload.files;
        if (files.length > 0) {
            data = new FormData();            

            for (var i = 0; i < files.length; i++) {               
                data.append(files[i].name, files[i]);

                var reader = new FileReader();

                reader.onload = function (event) {
                    $("#txtImagesChosen").append('<div class="col-sm-4"><img class="img-responsive" width="300" height = "300" src = "' + event.target.result + '" alt = "helperimage" ></div >');              
                };   

                reader.readAsDataURL(files[i]);
            }

            data.append("NumberOfImages", files.length);
            data.append("HelperId", $("#HelperId").val());
        }
        else {
            homecare.notify('Error Occurred', 'error');
        }

    });


    $("#btnHEISave").on("click", function () {
        if (data === null) {
            homecare.notify('Please select a new image', 'info');
        }
        else {
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadHelperImages",
                contentType: false,
                processData: false,
                data: data,
                success: function () {
                    $("#modalHelperImages").modal("hide");
                    resetHelperImagesForm();
                    homecare.notify("Saving Images Successfull", "success");
                },
                error: function () {
                    homecare.notify("There is an error in saving images process", "error");
                }
            });
        }       
    });


    $("body").on("click", ".btn-delete-image", function (e) {
        e.preventDefault();
        var imageid = $(this).data("imageid");
        var path = $(this).data("path");

        $.ajax({
            type: "POST",
            url: "/Admin/Upload/Delete",
            data: {
                ImageId: imageid,
                ImagePath: path
            },
            dataType: "json",
            success: function () {
                $(this).closest('div').remove();
                homecare.notify("Delete image successfully", "success");
            },
            error: function () {
                homecare.notify("Error Occurred", "error");
            }
        });
    });
}


function loadImages() {
    $.ajax({
        type: "GET",
        url: "/Admin/Upload/GetById",
        data: {
            helperId: $("#HelperId").val()
        },
        dataType: "json",
        success: function (res) {
            var render = "";
            $.each(res, function (i, item) {
                render += '<div class="col-sm-4"><img class="img-responsive" width="300" height = "300" src = "' + item.Path + '" alt = "helperimage" ><br/><a href="#" data-imageid = "' + item.Id + '" data-path = "' + item.Path + '" class="btn-delete-image">Delete</a></div >';
            });
            $("#txtImagesChosen").html(render);
        },
        error: function () {
            homecare.notify("Can not load Images","Error");
        }
    });
}


function resetHelperImagesForm() {
    $("#HelperId").val('');
    $("#txtImagesChosen").empty();
    $("#txtChoseImages").val('');
    data = null;
}