// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const menuToggle = document.querySelector('.menu-toggle');
const navbarMenu = document.querySelector('.nabvar__menu');

menuToggle.addEventListener('click', () => {
    menuToggle.classList.toggle('active');
    navbarMenu.style.display = navbarMenu.style.display === 'block' ? 'none' : 'block';
});