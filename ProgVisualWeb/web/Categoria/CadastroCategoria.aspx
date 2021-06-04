<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroCategoria.aspx.cs" Inherits="ProgVisualWeb.web.Categoria.CadastroCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProgVisual - Cadastro de Categoria</title>

    <link href="../../Content/pages.css" rel="stylesheet" />
    <link href="../../Content/bootstrap/bootstrap.css" rel="stylesheet" />
    
    <script src="../../Scripts/bootstrap/bootstrap.js"></script>
    <script src="../../Scripts/jquery-3.6.0.min.js"></script>
    <script src="../../Scripts/popper.min.js"></script>
    <script type="text/javascript" src="CadastroCategoria.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- Barra de navegação --%>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
              <div class="container-fluid">
                <a class="navbar-brand" href="PaginaInicial.aspx">Formulario Web</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                  <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                  <div class="navbar-nav">
                    <a class="nav-link" href="../Produto/CadastroProduto.aspx">Produto</a>
                    <a class="nav-link" href="#">Categoria</a>
                    <a class="nav-link" href="../Fornecedor/CadastroFornecedor.aspx">Fornecedor</a>
                    <a class="nav-link" href="../Marca/CadastroMarca.aspx">Marca</a>
                  </div>
                </div>
              </div>
            </nav>
            <%-- Corpo da pagina --%>
            <div class="page-content container">
                <br />
                <div id="divformularioCategoria" class="formularioCategoria">

                    <div class="row">
                        <div class="col-auto">
                            <label for="txtCodigo">Codigo</label> <br />
                            <input type="text" id="txtCodigo" class="form-control form-control-sm"/>
                        </div>
                        <div class="col-8">
                            <label for="txtDescriacao">Descrição</label> <br />
                            <input type="text" id="txtDescriacao" class="form-control form-control-sm"/>
                        </div>
                    </div>
                     <button type="button" id="BtnSalvarCategoria" class="btn btn-success">Salvar</button>
                    <br />
                </div>
                <br />
                <div id="divListagemCategorias">
                    <table border="1" class="table table-bordered table-sm table-hover">
                        <tr class="table-dark">
                            <th>Codigo</th>
                            <th>Descrição</th>
                            <th>Ações</th>
                        </tr>
                        <tbody id="bodyTableCategoria" class="table-light">

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>

    <div class="modal" id="modalCategoria" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="h-50 modal-header bg-dark">
            <h5 class="modal-title h-25 text-white fw-bolder" id="exampleModalLabel">
                Categoria
            </h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            
              <p></p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
           
          </div>
        </div>
      </div>
    </div>

</body>
</html>
