var Produto = null;

function NewProduto() {
    return {
        IDProduto: -1,
        Codigo: 0,
        CodigoBarras: '',
        Descricao: '',
        Preco: 0,
        IDCategoria: 0,
        Fornecedor: '',
        Marca: '',

        Novo: false,
        Editando: false,
        Remover: false
    };
}



// document functions ---------------------------------------------------------------------------------------------
function limparTela() {
    $("txtCodigo").val('');
    $("#txtCodigoBarras").val('');
    $("#txtDescricao").val('');
    $("#txtPreco").val('');
    $("#cmbCategoria").val('');
    $("#txtFornecedor").val('');
    $("#txtMarca").val('');
}

function Consultar() {

    // TABELA DE PRODUTOS
    $.ajax({
        type: "POST",
        url: "https://localhost:44344/web/Produto/HandlerProdutos.ashx?acao=0",
        data: "{}",
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: tabelaProdutos
    });

    //LISTA DE CATEGORIAS
    $.ajax({
        type: "POST",
        url: "https://localhost:44344/web/Categoria/HandlerCategoria.ashx?acao=0",
        data: "{}",
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: listaCategorias
    });
}

function OnSuccess() {
    Consultar();
    limparTela();
}

$(document).ready(function () {
    Consultar();

    $(document).on("click", "#BtnSalvar", function () {
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
        Produto.Fornecedor = $("#txtFornecedor").val();
        Produto.Marca = $("#txtMarca").val();

        //var Acao = Produto.Adicionar ? 1 : (Produto.Editando ? 2 : 0);

        // salvar no banco
        $.ajax({
            type: "POST",
            url: "https://localhost:44344/web/Produto/HandlerProdutos.ashx?acao=1",
            data: JSON.stringify(Produto),
            contentType: "application/json: charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            error:OnSuccess
        });
    });

    $(document).on("click", "#BtnEditar", function (resultado) {
        fnEditarProduto();
    });

    $(document).on("click", "#BtnExcluir", function () {
        debugger;

        var idProduto = $(this).attr('data-idprod');

        $.ajax({
            type: "POST",
            url: "https://localhost:44344/web/Produto/HandlerProdutos.ashx?acao=3",
            data: idProduto,
            contentType: "application/json: charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            error: OnSuccess
        });
    });

});

var CategoriasExistentes = null;
function listaCategorias(resultado){
    CategoriasExistentes = resultado;

    $("#cmbCategoria").html('');

    for (var i = 0; i < resultado.length; i++) {
        $("#cmbCategoria").append(
            new Option(resultado[i].Descricao, resultado[i].IDCategoria)
        );
    }

}

var ProdutosExistentes = null;
function tabelaProdutos(resultado) {
    ProdutosExistentes = resultado;

    $('#bodyTableProdutos').html('');
    for (var i = 0; i < resultado.length; i++) {
        var btnAçãos = "<button type='button' id='BtnEditar' class='btn btn-primary' onclick='fnEditarProduto(" + resultado[i].IDProduto + ");'>" + "Editar" + "</button>" +
                       "<button type='button' id='BtnExcluir' class='btn btn-danger' data-idprod='" + resultado[i].IDProduto + "'>" + "Excluir" + "</button>";

        $("#bodyTableProdutos").append(
            "<tr>" +
            "   <td>" + resultado[i].Codigo + "</td>" +
            "   <td>" + resultado[i].Descricao + "</td>" + 
            "   <td>" + resultado[i].Preco + "</td>" +
            "   <td>" + btnAçãos + "</td>" +
            "</tr>"
        );

        

    }
}

function fnEditarProduto(idProduto) {
    Produto = ProdutosExistentes.filter(function (a) {
        return a.IDProduto == idProduto;
    })[0];

    $("#txtCodigo").val(Produto.Codigo);
    $("#txtCodigoBarras").val(Produto.CodigoBarras);
    $("#txtDescricao").val(Produto.Descricao);
    $("#txtPreco").val(Produto.Preco);
    $("#cmbCategoria").val(Produto.IDCategoria);
    $("#txtFornecedor").val(Produto.Fonecedor);
    $("#txtMarca").val(Produto.Marca);

}
