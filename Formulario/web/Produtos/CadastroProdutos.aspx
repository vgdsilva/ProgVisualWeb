<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroProdutos.aspx.cs" Inherits="Formulario.web.Produtos.CadastroProdutos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Cadastro de Produto</title>

    <link href="../../Scripts/stylesheet/formulariostyles.css" rel="stylesheet" />

    <link href="../../Scripts/puglins/bootstrap-5.0.1/css/bootstrap.css" rel="stylesheet" />
    <link href="../../Scripts/stylesheet/formulariostyles.css" rel="stylesheet" />
    <link href="../../Scripts/puglins/fontawesome-free-5.15.3-web/css/all.css" rel="stylesheet" />

    <script type="text/javascript" src="../../Scripts/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" src="CadastroProdutos.js"></script>
    <script type="text/javascript" src="../../Scripts/puglins/bootstrap-5.0.1/js/bootstrap.js"></script>

</head>
<body>
     <%-- Modal de Categoria --%>
    <div class="modal" id="modalProduto" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header bg-success">
                <h5 class="modal-title text-white">Cadastro de Produto</h5>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="form-group col-md-3">
                        <label for="txtCodigo">Codigo</label>
                        <input type="text" id="txtCodigo" class="form-control form-control-sm" maxlength="8"/>
                    </div>
                    <div class="form-group col-md-9">
                        <label for="txtCodigoBarras">Codigo de Barras</label>
                        <input type="text" id="txtCodigoBarras" class="form-control form-control-sm"  maxlength="30"/>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-9">
                        <label for="txtDescricao">Descrição</label>
                        <input type="text" id="txtDescricao" class="form-control form-control-sm"/>
                    </div>
                     <div class="form-group col-md-3">
                        <label for="txtPreco">Preço</label>
                        <input type="text" id="txtPreco" class="form-control form-control-sm"/>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-4">
                        <label for="cmbCategoria">Categoria</label>
                        <select id="cmbCategoria" class="form-control form-control-sm"></select>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="cmbFornecedor">Fornecedor</label>
                        <select id="cmbFornecedor" class="form-control form-control-sm"></select>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="cmbMarca">Marca</label>
                        <select id="cmbMarca" class="form-control form-control-sm"></select>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" id="btnFechar" class="btn btn-secondary">Cancelar</button>
                <button type="button" id="btnSalvar" class="btn btn-success"><i class="fas fa-save"></i>  Salvar</button>
            </div>
        </div>
        </div>
    </div>

    <form id="form1" runat="server">
            <%-- Barra de Navegação --%>
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

        <div class="content">
            <div class="row">
                <div class="form-group col-md-12">
                    <div class="buttons-content d-grid gap-2 d-md-flex justify-content-md-end">
                        <button type="button" id="btnAdicionar" class="btn btn-success"><i class="fas fa-plus"></i> Adicionar </button>
                        <button type="button" id="btnExportar" class="btn btn-success"><i class="fas fa-file-csv"></i> Exportar .CSV </button>
                    </div>

                    <table border="1" class="table table-sm">
                        <tr class="table-dark">
                            <th>Codigo</th>
                            <th>Codigo de Barras</th>
                            <th>Descrição</th>
                            <th>Preço</th>
                            <th>Ações</th>
                        </tr>
                        <tbody id="bodyTableProdutos" class="table-light">
                        </tbody>
                    </table>
                </div>
            </div>
         </div>

    </form>
</body>
</html>
