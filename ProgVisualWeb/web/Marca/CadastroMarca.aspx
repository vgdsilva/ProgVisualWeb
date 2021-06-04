<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroMarca.aspx.cs" Inherits="ProgVisualWeb.web.Marca.CadastroMarca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProgVisual - Cadastro de Marca</title>

    <link href="../../Content/pages.css" rel="stylesheet" />
    <link href="../../Content/bootstrap/bootstrap.css" rel="stylesheet" />

    <script type="text/javascript" src="../../Scripts/bootstrap/bootstrap.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap/bootstrap.bundle.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-3.6.0.js"></script>
    <script type="text/javascript" src="../../Scripts/popper.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
              <div class="container-fluid">
                <a class="navbar-brand" href="PaginaInicial.aspx">Formulario Web</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                  <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                  <div class="navbar-nav">
                    <a class="nav-link" href="../Produto/CadastroProduto.aspx">Produto</a>
                    <a class="nav-link" href="../Categoria/CadastroCategoria.aspx">Categoria</a>
                    <a class="nav-link" href="../Fornecedor/CadastroFornecedor.aspx">Fornecedor</a>
                    <a class="nav-link" href="#">Marca</a>
                  </div>
                </div>
              </div>
            </nav>
            <div class="page-content container">
                <div id="divformularioMarcas" class="formularioMarcas">
                    <button type="button" id="" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">
                      Adicionar Marca
                    </button>
                </div>
                <div id="divListagemMarcas">
                    <table border="1" class="table">
                        <thead class="table-dark">
                            <th>Codigo</th>
                            <th>Descrição</th>
                        </thead>
                        <tbody id="bodyTableMarcas">

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
