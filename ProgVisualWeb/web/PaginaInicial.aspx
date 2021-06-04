<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="ProgVisualWeb.web.PaginaInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProgVisual - Pagina Inicial</title>
    <link href="../Content/pages.css" rel="stylesheet" />
    <link href="../Content/bootstrap/bootstrap.css" rel="stylesheet" />

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
                    <a class="nav-link" href="Produto/CadastroProduto.aspx">Produto</a>
                    <a class="nav-link" href="Categoria/CadastroCategoria.aspx">Categoria</a>
                    <a class="nav-link" href="Fornecedor/CadastroFornecedor.aspx">Fornecedor</a>
                    <a class="nav-link" href="Marca/CadastroMarca.aspx">Marca</a>
                  </div>
                </div>
              </div>
            </nav>
            <div class="page-content">

            </div>
        </div>
    </form>
</body>
</html>
