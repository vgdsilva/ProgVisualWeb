<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroFornecedor.aspx.cs" Inherits="Formulario.web.Fornecedores.CadastroFornecedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de Fornecedores</title>

    <link href="../../Scripts/puglins/bootstrap-5.0.1/css/bootstrap.css" rel="stylesheet" />
    <link href="../../Scripts/stylesheet/formulariostyles.css" rel="stylesheet" />
    <link href="../../Scripts/puglins/fontawesome-free-5.15.3-web/css/all.min.css" rel="stylesheet" />

    <script type="text/javascript" src="../../Scripts/puglins/bootstrap-5.0.1/js/bootstrap.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <div class="container-fluid">
                <a class="navbar-brand" href="../PaginaInicial.aspx">Formulario Web</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link text-white" href="../Produtos/CadastroProdutos.aspx">Produto</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-white" href="../Categorias/CadastroCategoria.aspx">Categoria</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-white" href="../Fornecedores/CadastroFornecedor.aspx">Fornecedor</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-white" href="../Marca/CadastroMarca.aspx">Marca</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-white" href="../Emails/CadastroEmail.aspx">Email</a>
                        </li>
                    </ul>
                    <div class="d-flex">
                        <a class="btn text-white" href="../Configuracoes/Configuracoes.aspx">Configurações</a>
                    </div>
                </div>
                </div>
            </nav>
        </div>
    </form>
</body>
</html>
