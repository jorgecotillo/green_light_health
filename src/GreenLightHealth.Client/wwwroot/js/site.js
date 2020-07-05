// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById("accept").addEventListener("click", setElementGreen);
document.getElementById("decline").addEventListener("click", setElementRed);

function setElementRed() {
    $("#stopbubble").removeClass("green");
    $("#stopbubble").toggleClass("red", true);
}
function setElementGreen() {
    $("#stopbubble").removeClass("red");
    $("#stopbubble").toggleClass("green", true);
 }
