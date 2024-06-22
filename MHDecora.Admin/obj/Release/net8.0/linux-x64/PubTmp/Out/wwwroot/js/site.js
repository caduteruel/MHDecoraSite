// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    // Espera 5 segundos (5000 milissegundos) antes de fechar o alerta
    setTimeout(function () {
        $('#autoCloseAlert').alert('close');
    }, 5000);
});

function Alert(titulo, mensagem, alerta) {
    // Fechando o modal no X
    $('.close').click();

    var msgAlert = '';
    $("#msgAlert").empty();

    msgAlert = "<div id='autoCloseAlert' class='alert alert-" + alerta + " alert-dismissible fade show' role='alert'>" +
        "<strong>" + titulo + "</strong> " + mensagem +
        "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" +
        "<span aria-hidden='true'>×</span>" +
        "</button>" +
        "</div>";

    $("#msgAlert").append(msgAlert);
       
    setTimeout(function () {
        $('#autoCloseAlert').alert('close');
    }, 5000);
}


