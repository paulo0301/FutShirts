function abrir(){
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
    document.querySelector('.efeito').style.display = "flex";
}
function fechar(){
    document.querySelector('.efeito').style.display = "none";
}

$(document).ready(function(){
    getSizeScreen();
});

$(window).resize(function() {
    getSizeScreen();
});

function getSizeScreen(){
    if($( window ).width() < 746){
        $('header').load('navegacao_mobile.html #header-mobile');
    } else {
        $('header').load('navegacao_desktop.html #header-desktop');   
    }
}

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