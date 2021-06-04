var Categoria = null;



function NewCategoria() {
    return {
        IDCategoria: -1,
        Codigo: 0,
        Descricao: '',

        Novo: false,
        Editando: false,
        Remover: false
    };
}


function ConsultaDados() {

    // TABELA DE CATEGORIAS
    $.ajax({
        type: "POST",
        url: "https://localhost:44344/web/Categoria/HandlerCategoria.ashx?acao=0",
        data: "{}",
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        success: tabelaCategorias
    });

}

$(document).ready(function () {
    ConsultaDados();

    /// Função para adicionar
    $(document).on("click", "#BtnSalvarCategoria", function () {
        debugger;

        if (Categoria == null) {
            Categoria = NewCategoria();
            Categoria.Novo = true;
        }

        Categoria.Codigo = $("#txtCodigo").val();
        Categoria.Descricao = $("#txtDescriacao").val();

        $.ajax({
            type: "POST",
            url: "https://localhost:44344/web/Categoria/HandlerCategoria.ashx?acao=1",
            data: JSON.stringify(Categoria),
            contentType: "application/json: charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            error: OnSuccess
        });
    });

    $(document).on("click", "#BtnEditar", function () {
        
    });

    /// Função para excluir 
    $(document).on("click", "#BtnExcluir", function () {
        debugger;

        var idCategoria = $(this).attr('data-idcat');

        $.ajax({
            type: "POST",
            url: "https://localhost:44344/web/Categoria/HandlerCategoria.ashx?acao=3",
            data: idCategoria,
            contentType: "application/json: charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            error: OnSuccess
        });
    });
    
});

function limparTela() {
    $("#txtCodigo").val('');
    $("#txtDescriacao").val('');
}


function OnSuccess() {
    ConsultaDados();
    limparTela();
}

//var CategoriasExistentes = null;
function tabelaCategorias(resultado) {
    CategoriasExistentes = resultado;

    $('#bodyTableCategoria').html('');
    for (var i = 0; i < resultado.length; i++) {
        var btnAçãos = "<button type='button' id='BtnEditar' class='btn btn-primary' onclick='fnEditarProduto(" + resultado[i].IDCategoria + ");'>" + "Editar" + "</button>" +
            "<button type='button' id='BtnExcluir' class='btn btn-danger' data-idcat='" + resultado[i].IDCategoria + "'>" + "Excluir" + "</button>";

        $("#bodyTableCategoria").append(
            "<tr>" +
            "   <td>" + resultado[i].Codigo + "</td>" +
            "   <td>" + resultado[i].Descricao + "</td>" +
            "   <td>" + btnAçãos + "</td>" +
            "</tr>"
        );
    };
}




