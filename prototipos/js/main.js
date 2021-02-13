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

    
function vermais(){
    var ultmais = document.getElementsByClassName("ultmais")[0];
    var ultmais1 = document.getElementsByClassName("ultmais")[1];

    if(ultmais.style.display == "none"){
        ultmais.style.display = "block";
        ultmais1.style.display = "block";
        document.getElementById("mais").innerText= "Ver menos"
    } 
    else{
        ultmais.style.display = "none";
        ultmais1.style.display = "none";
        document.getElementById("mais").innerText= "Ver mais";
    }
    
}


