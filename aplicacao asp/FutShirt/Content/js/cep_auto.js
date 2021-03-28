var v = false;
$(".cep").focusout(function () {
    $.ajax({
        url: 'https://viacep.com.br/ws/' + $(this).val() + '/json/unicode/',
        dataType: 'json',
        success: function (resposta) {
            $(".logradouro").val(resposta.logradouro);
            $(".complemento").val(resposta.complemento);
            $(".bairro").val(resposta.bairro);
            $(".cidade").val(resposta.localidade);
            $(".estado").val(resposta.uf);

            if (resposta.erro == true) {
                $("#errorCep").css('display', 'inline-block');
                v = false;  
            }
            else {
                $("#errorCep").css('display', 'none');
                $(".numero").focus();
                v = true;
            }
        }
    });
});
function validarCEP(e) {
    if (!v) e.preventDefault();
}