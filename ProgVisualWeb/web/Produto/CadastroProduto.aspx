<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroProduto.aspx.cs" Inherits="ProgVisualWeb.web.Produto.CadastroProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProgVisual - Cadastro de Produto</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    
    <link href="../../Content/pages.css" rel="stylesheet" />
    <link href="../../Content/toastr.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap/bootstrap.css" rel="stylesheet" />


    <script type="text/javascript" src="../../Scripts/bootstrap/bootstrap.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap/bootstrap.bundle.js"></script>
    <script src="../../Scripts/popper.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-3.6.0.js"></script>
    <script type="text/javascript" src="CadastroProduto.js"></script>

</head>
<body>
    <form id="form1" runat="server" >
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="../PaginaInicial.aspx">Formulario Web</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                    <div class="navbar-nav">
                        <a class="nav-link" href="#">Produto</a>
                        <a class="nav-link" href="../Categoria/CadastroCategoria.aspx">Categoria</a>
                        <a class="nav-link" href="../Fornecedor/CadastroFornecedor.aspx">Fornecedor</a>
                        <a class="nav-link" href="../Marca/CadastroMarca.aspx">Marca</a>
                    </div>
                </div>
            </div>
        </nav>
        <div class="page-content container">
            <div id="divformularioCategoria" class="formularioCategoria">
                  <div class="row">
                        <div class="col-auto">
                            <label for="txtCodigo">Codigo</label><br />
                            <input type="text" id="txtCodigo" class="form-control form-control-sm" maxlength="8"/>
                        </div>
                        <div class="col-9">
                            <label for="txtDescricao">Descrição</label><br />
                            <input type="text" id="txtDescricao" class="form-control form-control-sm"/>
                        </div>
                    </div>
                        <div class="col-auto">
                            <label for="txtCodigoBarras">Codigo de Barras</label><br />
                            <input type="text" id="txtCodigoBarras" class="form-control form-control-sm"  maxlength="30"/>
                        </div>
                        <div class="col-auto">
                            <label for="txtPreco">Preço</label><br />
                            <input type="text" id="txtPreco" class="form-control form-control-sm"/>
                        </div>
                   <div class="row">
                        <div class="col-3">
                            <label for="cmbCategoria">Categoria</label><br />
                            <select id="cmbCategoria" class="form-select form-select-sm"></select>
                        </div>
                        <div class="col-5">
                            <label for="txtFornecedor">Fornecedor</label><br />
                            <input type="text" id="txtFornecedor " class="form-control form-control-sm"/>
                        </div>
                        <div class="col-4">
                            <label for="txtMarca">Marca</label><br />
                            <input type="text" id="txtMarca" class="form-control form-control-sm"/>
                        </div>
                    </div>
                    <br />
                    <div>
                        <button type="button" id="BtnSalvar" class="btn btn-success btn-lg">Salvar</button>
                    </div>

                </div>
         </div>

        <br />
        <div id="divListagemProdutos" class="listagem-produto container-lg">
            <table border="1" class="table table-sm">
                <tr class="table-dark">
                    <th>Codigo</th>
                    <th>Descrição</th>
                    <th>Preço</th>
                    <th>Ações</th>
                </tr>
                <tbody id="bodyTableProdutos" class="table-light">
                </tbody>
            </table>
        </div>
    </form>


</body>
</html>
