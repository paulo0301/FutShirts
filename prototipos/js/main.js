function abrir(){
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
    document.querySelector('.efeito').style.display = "flex";
}
function fechar(){
    document.querySelector('.efeito').style.display = "none";
}


var btMenu = document.querySelector(".menu-hamburger");
var menuLado = document.querySelector("#navegacao02");
var fecharMenu = document.querySelector(".area-fechar-nav");

btMenu.addEventListener('click', () => {
    menuLado.classList.add("mostrar-menu");
})
fecharMenu.addEventListener('click', () => {
    menuLado.classList.remove("mostrar-menu");
})

$(document).ready(function(){
    /////////////////////////////////////
    $("section.vantagens ul").owlCarousel({
        loop: true,
        margin: 0,
        autoplay: true,
        autoplayTimeout: 5000,
        lazyLoad: true,
        nav: false,
        dots: true,
        responsive: {
            0: {
                items: 1,
            },
            700: {
                items: 5,
                loop: false,
            }
        }
    })
});