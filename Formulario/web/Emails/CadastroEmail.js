var localhost = "https://localhost:44348";
var Email = null;

function newEmail() {
    return {
        Assunto: '',
        Destinatario: '',
        Mensagem: ''
    };
}

$(document).ready(function () {

    $(document).on("click", "#btnAdicionar", function () {
        limparTelaEmail();
        $("#modalEmail").modal("show");
    });

    $(document).on("click", "#btnFechar", function () {
        $("#modalEmail").modal("hide");
    });

    $(document).on("click", "#btnEnviar", function () {

        Email = newEmail();

        Email.Assunto = $("#txtAssunto").val();
        Email.Destinatario = $("#txtDestinatario").val();
        Email.Mensagem = $("#txtMensagem").val();

        $.ajax({
            type: "POST",
            url: localhost + "/web/Emails/HandlerEmail.ashx",
            data: JSON.stringify(Email),
            contentType: "application/json: charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            error: OnSuccess
        });
    });
});


function OnSuccess() {
    limparTelaEmail();
    $("#modalEmail").modal("hide");
}

function limparTelaEmail() {
    $("#txtAssunto").val('');
    $("#txtDestinatario").val('');
    $("#txtMensagem").val('');
}