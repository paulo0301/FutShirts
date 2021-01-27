document.querySelector("input#entrar").onclick = function abrir(){
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
    document.querySelector('.efeito').style.visibility = "visible";
}
document.querySelector("input#entrar2").onclick = function abrir(){
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
    document.querySelector('.efeito').style.visibility = "visible";
}
document.querySelector("input#fechar").onclick = function fechar(){
    document.querySelector('.efeito').style.visibility = "hidden";
}


var btMenu = document.querySelector(".menu-hamburger");
var menuLado = document.querySelector("#navegacao02");
var fecharMenu = document.querySelector(".area-fechar-nav");

btMenu.addEventListener('click', () => {
    menuLado.style.left = "0";
})
fecharMenu.addEventListener('click', () => {
    menuLado.style.left = "-100%";
})