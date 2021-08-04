var localhost = "https://localhost:44348";

var Produto = null;
var ProdutosExistentes = null;
var CategoriasExistentes = null;
var MarcasExistente = null;
var FornecedoresExistentes = null;


function NewProduto() {
    return {
        IDProduto: -1,
        Codigo: 0,
        CodigoBarras: '',
        Descricao: '',
        Preco: 0,
        IDCategoria: 0,
        IDFornecedor: 0,
        IDMarca: 0,
        Novo: false,
        Editando: false,
        Remover: false
    };
}


$(document).ready(function () {
    Consultar();

    $(document).on("click", "#btnAdicionar", function () {
        limparTela();
        Produto = null;
        abrirModal();
    });

    $(document).on("click", "#btnFechar", function () {
        fecharModal();
    });

    $(document).on("click", "#btnSalvar", function () {
       debugger;

        if (Produto == null) {
            Produto = NewProduto();
            Produto.Novo = true;
        }

        Produto.Codigo = $("#txtCodigo").val();
        Produto.CodigoBarras = $("#txtCodigoBarras").val();
        Produto.Descricao = $("#txtDescricao").val();
        Produto.Preco = parseFloat($("#txtPreco").val());
        Produto.IDCategoria = $("#cmbCategoria").val();
        Produto.IDFornecedor = $("#cmbFornecedor").val();
        Produto.IDMarca = $("#cmbMarca").val();

        var Acao = Produto.Novo ? 1 : (Produto.Editando ? 2 : 0);

        // salvar no banco
        $.ajax({
            type: "POST",
            url: localhost + "/web/Produtos/HandlerProdutos.ashx?acao=" + Acao,
            data: JSON.stringify(Produto),
            contentType: "application/json: charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            error: OnSuccess
        });
    });

    $(document).on("click", "#BtnExcluir", function () {
        debugger;

        var idProduto = $(this).attr('data-idprod');

        $.ajax({
            type: "POST",
            url: localhost + "/web/Produtos/HandlerProdutos.ashx?acao=3",
            data: idProduto,
            contentType: "application/json: charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            error: OnSuccess
        });
    });

});

function OnSuccess() {
    Consultar();
    limparTela();
    fecharModal();
}

function Consultar() {

    // TABELA DE PRODUTOS
    $.ajax({
        type: "POST",
        url: localhost + "/web/Produtos/HandlerProdutos.ashx?acao=0",
        data: "{}",
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: tabelaProdutos
    });

    //LISTA DE CATEGORIAS
    $.ajax({
        type: "POST",
        url: localhost + "/web/Categorias/HandlerCategoria.ashx?acao=0",
        data: "{}",
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: listaCategorias
    });

    // Lista de Marcas
    $.ajax({
        type: "POST",
        url: localhost + "/web/Marca/HandlerMarca.ashx?acao=0",
        data: "{}",
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: listaMarcas
    });

    // LISTA DE FORNECEDORES
    $.ajax({
        type: "POST",
        url: localhost + "/web/Fornecedores/HandlerFornecedor.ashx?acao=0",
        data: "{}",
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: listaFornecedores
    });
}

function limparTela() {
    $("#txtCodigo").val('');
    $("#txtCodigoBarras").val('');
    $("#txtDescricao").val('');
    $("#txtPreco").val('');
    $("#cmbCategoria").val('');
    $("#cmbFornecedor").val('');
    $("#cmbMarca").val('');
}

function listaCategorias(resultado) {
    CategoriasExistentes = resultado;

    $("#cmbCategoria").html('');

    for (var i = 0; i < resultado.length; i++) {
        $("#cmbCategoria").append(
            new Option(resultado[i].Descricao, resultado[i].IDCategoria)
        );
    }
}

function listaFornecedores(resultado) {
    debugger;
    FornecedoresExistentes = resultado;

    $("#cmbFornecedor").html('');
    for (var i = 0; i < resultado.length; i++) {
        $("#cmbFornecedor").append(
            new Option(resultado[i].Descricao, resultado[i].IDFornecedor)
        );
    }
}

function listaMarcas(resultado) {
    MarcasExistente = resultado;

    $("#cmbMarca").html('');
    for (var i = 0; i < resultado.length; i++) {
        $("#cmbMarca").append(
            new Option(resultado[i].Descricao, resultado[i].IDMarca)
        );
    }
}

function tabelaProdutos(resultado) {
    ProdutosExistentes = resultado;

    $("#bodyTableProdutos").html('');
    for (var i = 0; i < resultado.length; i++) {
        var btnAçãos = "<button type='button' id='BtnEditar' class='btn btn-primary' onclick='fnEditarProduto(" + resultado[i].IDProduto + ");'>" + "Editar" + "</button>" +
            "<button type='button' id='BtnExcluir' class='btn btn-danger' data-idprod='" + resultado[i].IDProduto + "'>" + "Excluir" + "</button>";

        $("#bodyTableProdutos").append(
            "<tr>" +
            "   <td>" + resultado[i].Codigo + "</td>" +
            "   <td>" + resultado[i].CodigoBarras + "</td>" +
            "   <td>" + resultado[i].Descricao + "</td>" +
            "   <td>" + resultado[i].Preco + "</td>" +
            "   <td>" + btnAçãos + "</td>" +
            "</tr>"
        );
    }
}

function fnEditarProduto(idProduto) {
    Produto = ProdutosExistentes.filter(function (produto) {
        return produto.IDProduto ==  idProduto;
    })[0];

    Produto.Editando = true;
    $("#txtCodigo").val(Produto.Codigo);
    $("#txtCodigoBarras").val(Produto.CodigoBarras);
    $("#txtDescricao").val(Produto.Descricao);
    $("#txtPreco").val(Produto.Preco);
    $("#cmbCategoria").val(Produto.IDCategoria);
    $("#cmbFornecedor").val(Produto.IDFornecedor);
    $("#cmbMarca").val(Produto.IDMarca);

    $("#modalProduto").modal('show');
}

function abrirModal() {
    $("#modalProduto").modal('show');
}

function fecharModal() {
    $("#modalProduto").modal('hide');
}
