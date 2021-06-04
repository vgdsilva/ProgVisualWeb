<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroFornecedor.aspx.cs" Inherits="ProgVisualWeb.web.Fornecedor.CadastroFornecedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProgVisual - Cadastro de Fornecedor</title>

    <link href="../../Content/pages.css" rel="stylesheet" />
    <link href="../../Content/bootstrap/bootstrap.css" rel="stylesheet" />

    <script type="text/javascript" src="../Categoria/CadastroCategoria.js"></script>
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
                    <a class="nav-link" href="#">Fornecedor</a>
                    <a class="nav-link" href="../Marca/CadastroMarca.aspx">Marca</a>
                  </div>
                </div>
              </div>
            </nav>
            <div class="page-content container">
                <div id="divformularioFornecedor" class="formularioFornecedor">
                    <button type="button" id="" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalFornecedor">
                      <i class=""></i>Adicionar Categoria
                    </button>
                </div>
                <div id="divListagemFornecedor">
                    <table border="1" class="table">
                        <thead class="table-dark">
                            <th>Codigo</th>
                            <th>Descrição</th>
                        </thead>
                        <tbody id="bodyTableFornecedor">

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>


    <div class="modal fade" id="modalFornecedor" tabindex="-1" aria-labelledby="ModalFornecedor" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="ModalFornecedor">Modal title</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            ...
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
          </div>
        </div>
      </div>
    </div>
</body>
</html>
