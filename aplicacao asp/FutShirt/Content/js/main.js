function abrir(){
    if($(window).width() > 746){
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
    document.querySelector('.efeito').style.display = "flex";
    }
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
        document.querySelector('.efeito').style.display = "none";
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

function trocaimg(){
    var trc = document.getElementsByClassName("cami").style.src;
    trc = "imagens/camisamarcada.png";

}


