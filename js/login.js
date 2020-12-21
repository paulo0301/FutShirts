document.querySelector("input#entrar").onclick = function abrir(){
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
    document.querySelector('.efeito').style.visibility = "visible";
}
document.querySelector("input#fechar").onclick = function fechar(){
    document.querySelector('.efeito').style.visibility = "hidden";
}