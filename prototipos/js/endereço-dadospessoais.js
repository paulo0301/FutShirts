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

var cpf = document.getElementById("cpf");
var validado = false;
var containerCpf = document.querySelector("#containerInputCpf");
cpf.addEventListener("blur", () =>{
    var cpfLimpo = cpf.value.replace(/\D/g, "");

    if((cpfLimpo.length === 11) && (TestaCPF(cpfLimpo))){
        containerCpf.classList.add("input-valido");
        containerCpf.classList.remove("input-invalido");
    }
    else if((cpfLimpo.length === 11) && (TestaCPF(!cpfLimpo))){
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
    }
    else if(cpfLimpo.length != 11){
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
    }
})
cpf.addEventListener("keyup", () =>{
    var cpfLimpo = cpf.value.replace(/\D/g, "");

    if((cpfLimpo.length === 11) && (TestaCPF(cpfLimpo))){
        containerCpf.classList.add("input-valido");
        containerCpf.classList.remove("input-invalido");

        validado = true;
    }
    else if((cpfLimpo.length === 11) && (TestaCPF(!cpfLimpo))){
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
    }
    else if(cpfLimpo.length === 0){
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
        validado = false;
    }
    else if(validado){
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
    }
})

function TestaCPF(strCPF) {
    var Soma;
    var Resto;
    Soma = 0;
  if (strCPF == "00000000000") return false;
  if (strCPF == "11111111111") return false;
  if (strCPF == "22222222222") return false;
  if (strCPF == "33333333333") return false;
  if (strCPF == "44444444444") return false;
  if (strCPF == "55555555555") return false;
  if (strCPF == "66666666666") return false;
  if (strCPF == "77777777777") return false;
  if (strCPF == "88888888888") return false;
  if (strCPF == "99999999999") return false;

  for (i=1; i<=9; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (11 - i);
  Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10)) ) return false;

  Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11) ) ) return false;
    return true;
}