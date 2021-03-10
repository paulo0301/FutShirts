function mascara(t, mask){
    var i = t.value.length;
    var saida = mask.substring(1,0);
    var texto = mask.substring(i)
    if (texto.substring(0,1) != saida){
    t.value += texto.substring(0,1);
    }
}
//Verificar se o COF é válido
var cpf = document.getElementById("cpf");
var validado = false;
var containerCpf = document.querySelector("#containerInputCpf");

cpf.addEventListener("blur", () => {
    var cpfLimpo = cpf.value.replace(/\D/g, "");

    if ((cpfLimpo.length === 11) && (TestaCPF(cpfLimpo))) {
        containerCpf.classList.add("input-valido");
        containerCpf.classList.remove("input-invalido");
    }
    else if ((cpfLimpo.length === 11) && (TestaCPF(!cpfLimpo))) {
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
    }
    else if (cpfLimpo.length != 11) {
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
    }
})
cpf.addEventListener("keyup", () => {
    var cpfLimpo = cpf.value.replace(/\D/g, "");

    if ((cpfLimpo.length === 11) && (TestaCPF(cpfLimpo))) {
        containerCpf.classList.add("input-valido");
        containerCpf.classList.remove("input-invalido");

        validado = true;
    }
    else if ((cpfLimpo.length === 11) && (TestaCPF(!cpfLimpo))) {
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
    }
    else if (cpfLimpo.length === 0) {
        containerCpf.classList.remove("input-valido");
        containerCpf.classList.add("input-invalido");
        validado = false;
    }
    else if (validado) {
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

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) return false;
    return true;
}

//Validar Senha e Confirmar Senha
var senha = document.getElementById("senha");
var confSenha = document.getElementById("confsenha");
var containerSenha = document.getElementById("containerInputSenha");
var containerConfSenha = document.getElementById("containerInputConfSenha");

senha.addEventListener("keyup", () => {
    if (VerificarSenha(senha.value)) {
        containerSenha.classList.add("input-valido");
        containerSenha.classList.remove("input-invalido");
    }
    else {
        containerSenha.classList.remove("input-valido");
        containerSenha.classList.add("input-invalido");
    }
})
confSenha.addEventListener("keyup", () => {
    if (VerificarConfirmarSenha(senha.value, confSenha.value)) {
        containerConfSenha.classList.add("input-valido");
        containerConfSenha.classList.remove("input-invalido");
    }
    else {
        containerConfSenha.classList.remove("input-valido");
        containerConfSenha.classList.add("input-invalido");
    }
})
function VerificarSenha(strSenha) {
    if (strSenha.length < 8) return false;
    if (strSenha.length >= 8) return true;
}
function VerificarConfirmarSenha(strSenha, strConfSenha) {
    if (strSenha == strConfSenha && strConfSenha.length >= 8) return true;
    else return false;
}

//Veficar se é maior de 18 anos
function ValidarIdade() {
    var inputNasc = document.getElementById("nascimento");
    let nasc = inputNasc.value.split("/").map(Number);
    let depois18anos = new Date(nasc[2] + 18, nasc[1] - 1, nasc[0]);
    let agora = new Date();
    console.log(inputNasc.value)
    console.log(nasc);
    console.log(depois18anos);
    console.log(agora);
    if (depois18anos <= agora) {
        return true;
    }
    else return false;
}
////////////////////////////////////////////////////
function verificar(e) {
    var cpfLimpo = cpf.value.replace(/\D/g, "");
    var mensagem = document.getElementById("alertaIdade");

    if (cpfLimpo.length != 11 || TestaCPF(cpfLimpo) == false) {
        e.preventDefault();
    }
    if (senha.value.length < 8 || senha.value != confSenha.value) {
        e.preventDefault();
    }
    if (ValidarIdade() == false) {
        e.preventDefault();
        mensagem.classList.add("visivel-inline");
        mensagem.classList.remove("invisivel");
    }
}