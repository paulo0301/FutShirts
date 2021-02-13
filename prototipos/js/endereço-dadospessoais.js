function mascara(t, mask){
    var i = t.value.length;
    var saida = mask.substring(1,0);
    var texto = mask.substring(i)
    if (texto.substring(0,1) != saida){
    t.value += texto.substring(0,1);
    }
}
 function proseg(){
    var conf = document.getElementById("conf");
    var senha = document.getElementById("password").value;
    var confSenha = document.getElementById("confpassword").value;

    if(senha == confSenha){
        alert('Aguarde o codigo de confirmação para validar o cadastro!');
    }
    else {
        alert("As senhas não conferem!");
    }
}