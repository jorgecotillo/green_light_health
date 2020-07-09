// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function setElementRed(stoplightId, greenBulbId, redBulbId, healthModalId, qrCodeId) {
    $("#" + stoplightId).removeClass("green");
    $("#" + greenBulbId).removeClass("green");
    $("#" + stoplightId).toggleClass("red", true);
    $("#" + redBulbId).toggleClass("red", true);
    $("#" + healthModalId).modal('hide');
    $("#" + qrCodeId).show();
    $("#" + qrCodeId).toggleClass("red", true);
}

function setElementGreen(stoplightId, greenBulbId, redBulbId, healthModalId, qrCodeId) {
    $("#" + stoplightId).removeClass("red");
    $("#" + redBulbId).removeClass("red");
    $("#" + stoplightId).toggleClass("green", true);
    $("#" + greenBulbId).toggleClass("green", true);
    $("#" + healthModalId).modal('hide');
    $("#" + qrCodeId).show();
    $("#" + qrCodeId).toggleClass("green", true);
}

$(document).ready(() => {
    let user = localStorage.getItem('firstNameLastName');
    if (!user) {
        $('#registration-form').modal({
            backdrop: 'static'
        });('show');
        $('#welcome-text').html("Welcome!");
    }
    else {
        $('#health-declaration-form').modal({
            backdrop: 'static'
        });('show');
        $('#welcome-text').html(user);
    }
});

 $('#modalRegisterFormButton').click(function(e) {
    e.preventDefault();
     var name = $('input#orangeForm-name').val();
     if (name == "") {
        $('#feedback').removeClass("hidden");
     }
     else {
        localStorage.setItem('firstNameLastName',name);
        $('#registration-form').modal('hide');
        $('#health-declaration-form').modal({
           backdrop: 'static'
        });('show');
        $('#welcome-text').html(name);
     }
 });

$('#registration-form').on('hidden.bs.modal', function () {
    let user = localStorage.getItem('firstNameLastName');
    if (!user) {
        $('#registration-form').modal({
            backdrop: 'static'
        });('show');
    }
    });