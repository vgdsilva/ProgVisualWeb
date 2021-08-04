var localhost = "https://localhost:44348";
var Categoria = null;

var codigo = NextID;

function NewCategoria() {
    return {
        IDCategoria: -1,
        Codigo: 0,
        Descricao: '',

        isNovo: false,
        isEditando: false,
        isRemovendo: false
    };
}

function ConsultaDados() {

    // TABELA DE CATEGORIAS
    $.ajax({
        type: "POST",
        url: localhost + "/web/Categorias/HandlerCategoria.ashx?acao=0",
        data: "{}",
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: tabelaCategorias
    });
}

function NextID() {
    debugger;

    $.ajax({
        url: localhost + "/web/Categorias/CadastroCategoria.aspx/NextIDCategoria",
        data: "{}",
        dataType: "json",
        success:
    });
}

$(document).ready(function () {
    ConsultaDados();

    // Abrir modal
    $(document).on("click", "#btnAdicionar", function () {
        limparTela();
        Categoria = null;
        $("#modalCategoria").modal('show');
        //$("#txtCodigo").val(codigo);
    });

    //Fechar Modal
    $(document).on("click", "#btnFechar", function () {
        fecharModal();
    });

    /// Função para adicionar
    $(document).on("click", "#btnSalvar", function () {
        salvarCategoria();
    });

    /// Função para excluir 
    $(document).on("click", "#btnExcluir", function () {
        debugger;
        excluirCategoria();
    });

});

function limparTela() {
    $("#txtCodigo").val('');
    $("#txtDescricao").val('');
}

function salvarCategoria() {
    debugger;

    if (Categoria == null) {
        Categoria = NewCategoria();
        Categoria.Novo = true;
    }

    Categoria.Codigo = $("#txtCodigo").val();
    Categoria.Descricao = $("#txtDescricao").val();

    if ($('#txtCodigo').val() == '') {
        alert('Campo codigo em Branco');

        $('#txtCodigo').focus();

        return false;
    } else if ($('#txtDescricao').val() == '') {

        alert('Campo Descrição em branco!');

        return false;
    }

    var Acao = Categoria.Novo ? 1 : (Categoria.Editando ? 2 : 0);

    $.ajax({
        type: "POST",
        url: localhost + "/web/Categorias/HandlerCategoria.ashx?acao=" + Acao,
        data: JSON.stringify(Categoria),
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnSuccess
    });
}

function OnSuccess() {
    fecharModal();
    ConsultaDados();
    limparTela();
}

function carregarDados() {
    $("#txtCodigo").val(Categoria.Codigo);
    $("#txtDescricao").val('');
}

function abrirModal() {
    $("#modalCategoria").modal('show');
}

function fecharModal() {
    $("#modalCategoria").modal('hide');
}

var CategoriasExistentes = null;
function tabelaCategorias(resultado) {
    CategoriasExistentes = resultado;


    $('#bodyTableCategoria').html('');
    for (var i = 0; i < resultado.length; i++) {
        var btnAçãos = "<button type='button' id='btnEditar' class='btn btn-primary btn-editar' onclick='editarCategoria(" + resultado[i].IDCategoria + ");'>" + "Editar" + "</button>" +
            "<button type='button' id='btnExcluir' class='btn btn-danger' data-idcat='" + resultado[i].IDCategoria + "'>" + "Excluir" + "</button>";

        $("#bodyTableCategoria").append(
            "<tr>" +
            "   <td>" + resultado[i].Codigo + "</td>" +
            "   <td>" + resultado[i].Descricao + "</td>" +
            "   <td>" + btnAçãos + "</td>" +
            "</tr>"
        );
    }
}

function editarCategoria(idCategoria) {

    debugger
    Categoria = CategoriasExistentes.filter(function (a) {
        return a.IDCategoria == idCategoria;
    })[0];

    Categoria.Editando = true;
    $("#txtCodigo").val(Categoria.Codigo);
    $("#txtDescricao").val(Categoria.Descricao);

    abrirModal();
}

function excluirCategoria() {

    var idCategoria = $(this).attr('data-idcat');

    $.ajax({
        type: "POST",
        url: localhost + "/web/Categorias/HandlerCategoria.ashx?acao=3",
        data: idCategoria,
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnSuccess
    });
}



