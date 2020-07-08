// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function setElementRed(elementId) {
    $(elementId).removeClass("green");
    $(elementId).toggleClass("red", true);
    $('#health-declaration-form').modal('hide');
}

function setElementGreen(elementId) {
    $(elementId).removeClass("red");
    $(elementId).toggleClass("green", true);
    $('#health-declaration-form').modal('hide');
}

$(document).ready(() => {
    let user = localStorage.getItem('firstNameLastName');
    if (!user) {
        $('#registration-form').modal('show');
    }
    else {
        $('#health-declaration-form').modal('show');
    }
});

 $('#modalRegisterFormButton').click(function(e) {
    e.preventDefault();
    var name = $('input#orangeForm-name').val()
    localStorage.setItem('firstNameLastName',name);
     $('#btn-close').click();
     $('#health-declaration-form').modal('show');
});