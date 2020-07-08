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

 window.onload = (event) => {
    let user = localStorage.getItem('user') 
    if (!user) {
        $('#modalRegisterForm').modal('show');
    }
    else {
        //populate the view with name etc
    }
 }

 $('#modalRegisterFormButton').click(function(e) {
    e.preventDefault();
    var email = $('input#orangeForm-email').val()
    var name = $('input#orangeForm-name').val()
    localStorage.setItem('firstNameLastName',name);
});