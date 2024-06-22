// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {


    $('.owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        dots: false,
        responsive: {
            0: {
                items: 2 // Ajuste o número de itens visíveis para 2 em telas menores
            },
            600: {
                items: 6 // Ajuste o número de itens visíveis para 4 em telas maiores
            }
        }
    });
});