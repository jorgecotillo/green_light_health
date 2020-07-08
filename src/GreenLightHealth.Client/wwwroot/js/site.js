// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function setElementRed(elementId) {
    $(elementId).removeClass("green");
    $(elementId).toggleClass("red", true);
}

function setElementGreen(elementId) {
    $(elementId).removeClass("red");
    $(elementId).toggleClass("green", true);
}

$(document).ready(() => {
    let user = localStorage.getItem('firstNameLastName');
    console.log("user is: ", user);
    if (!user) {
        $('#registration-form').modal('show');
    }
    else {
        // TODO: populate the view with name, etc.
    }
});

 $('#modalRegisterFormButton').click(function(e) {
    e.preventDefault();
    var name = $('input#orangeForm-name').val()
    localStorage.setItem('firstNameLastName',name);
});