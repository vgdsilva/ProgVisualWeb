<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroEmail.aspx.cs" Inherits="Formulario.web.Emails.CadastroEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro Email</title>

    <script type="text/javascript" src="../../Scripts/jquery-3.6.0.min.js"></script>
    <link href="../../Scripts/puglins/bootstrap-5.0.1/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/puglins/bootstrap-5.0.1/js/bootstrap.js"></script>

    <link href="../../Scripts/puglins/fontawesome-free-5.15.3-web/css/all.css" rel="stylesheet" />


    <script type="text/javascript" src="CadastroEmail.js"></script>

</head>
<body>

    <%-- Modal de Categoria --%>
    <div class="modal" id="modalEmail" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header bg-success">
                <h5 class="modal-title text-white">Envio de Email</h5>
            </div>
            <div class="modal-body">
            <div class="row">
                    <div class="form-group col-md-12">
                        <label for="txtAssunto">Assunto</label>
                        <input type="text" id="txtAssunto" class="form-control form-control-sm"/>
                    </div>
                    <div class="form-group col-md-12">
                        <label for="txtDestinatario">Destinatario</label>
                        <input type="text" id="txtDestinatario" class="form-control form-control-sm"/>
                    </div>
                <div class="form-group col-md-12">
                        <label for="txtMensagem">Mensagem</label>
                        <textarea type="text" id="txtMensagem" class="form-control form-control-sm" style="height: 200px"></textarea>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" id="btnFechar" class="btn btn-secondary">Cancelar</button>
                <button type="button" id="btnEnviar" class="btn btn-success">Enviar</button>
            </div>
        </div>
        </div>
    </div>


    <form id="form1" runat="server">
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
                            <a class="nav-link text-white" href="Emails/CadastroEmail.aspx">Email</a>
                        </li>
                    </ul>
                    <div class="d-flex">
                        <a class="btn text-white" href="../Configuracoes/Configuracoes.aspx">Configurações</a>
                    </div>
                </div>
                </div>
            </nav>
            <div class="content">
                    <div class=" container">

                    <br />
                        <button type="button" id="btnAdicionar" class="btn btn-primary"><i class="fas fa-plus"></i> Adicionar Email </button>
                    <br />
                    <br />

                    <div id="divListagemEmail">
                        <table border="1" class="table table-bordered table-sm table-hover">
                            <tr class="table-dark">
                                <th>Assunto</th>
                                <th>Destinatario</th>
                                <th>Mensagem</th>
                            </tr>
                            <tbody id="bodyTableEmail" class="table-light">

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
