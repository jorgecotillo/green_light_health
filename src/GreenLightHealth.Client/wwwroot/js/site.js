// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById("accept").addEventListener("click", agreeToHealthDec);
document.getElementById("decline").addEventListener("click", declineHealthDec);
//TODO figure out what needs to happen here, maybe just highlight for now
function agreeToHealthDec() {
    alert ("@User.Identity.Name agrees to health declaration");
}
    function declineHealthDec() {
    alert ("@User.Identity.Name declines health declaration");
}