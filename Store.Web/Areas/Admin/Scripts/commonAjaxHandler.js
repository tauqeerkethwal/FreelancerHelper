var commonAjaxManager = new function () {
    var _this = this;


    this.deleteRecordAsync = function (url, data, onSuccess, onError) {
   
        $.ajax({
            url: url,
            type: 'Post',
            data: data,
            //dataType: "text/html",
            //async: true,
            cache: false,
            success: function (data) {
               
                if (onSuccess) {
                    onSuccess(data);
                }

            },

            error: function (xhr) {
                //alert("error");
                if (onError) {
                    onError();
                }
            }


        });


    }


    this.loadPartialAsync = function (url, pageTitle) {

        $.ajax({
            url: url,
            type: 'get',
            data: null,
            //dataType: "text/html",
            //async: true,
            cache: false,
            success: function (data) {

                $("#partialFormBody").html(data);
                $("#partialFormLabel").html(pageTitle);
                $('#partialFormModel').modal('show');

            },

            error: function (xhr) {
               
                commonManager.showErrorMessage("Unknown Error Occurred.");

            }


        });


    }


    this.hidePartialPopup = function () {


        $('#partialFormModel').modal('hide');


    }


    this.postAsync = function (url, data, onSuccess, onError) {

        $.ajax({
            url: url,
            type: 'Post',
            data: data,
           // dataType: "json",
           // contentType: "application/json",
            cache: false,
            success: function (data) {

                if (onSuccess) {
                    onSuccess(data);
                }

            },

            error: function (xhr) {

                commonManager.showErrorMessage("Unknown Error Occurred.");
                if (onError) {
                    onError();
                }
            }


        });


    }


};





//This file contains common js functions
var noprogressbar = false;

var timer;
$(function () {

    InitSiteSetup();

});

//This function will include common functionality shared between pages
//Ajax loading image on every request
function InitSiteSetup() {

    //$.ajaxSetup({
    //    // Disable caching of AJAX responses
    //    cache: false,
    //    timeout: 950000
    //});

    $(document).ajaxError(function (error, xhr, options) {
        if (xhr.status == 401 || xhr.status == 403) {
            //window.location.href = "";
        }

        commonManager.showErrorMessage("Unknown error occured. ");

    });

    $(document).ajaxStart(function () {
        Main_ShowLoader()

    });

    $(document).ajaxStop(function () {

        Main_HideLoader();

    });
}



function Main_ShowLoader() {
    if (!noprogressbar) {

        $("body").prepend("<div class='edc-loader'>Loading...</div>");

    }
}

function Main_HideLoader() {
    noprogressbar = false;
    jQuery(".edc-loader").remove();
}
