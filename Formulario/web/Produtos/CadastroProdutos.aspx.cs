using Formulario.Regras.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario.web.Produtos
{
    public partial class CadastroProdutos : System.Web.UI.Page
    {

        private string ChaveSessao = "S_CONTROLLER";
        private ProdutoBO ControllerProduto
        {
            get
            {
                if (HttpContext.Current.Session[ChaveSessao] == null)
                    HttpContext.Current.Session[ChaveSessao] = new ProdutoBO();

                return HttpContext.Current.Session[ChaveSessao] as ProdutoBO;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback && !Page.IsPostBack)
                HttpContext.Current.Session[ChaveSessao] = null;
        }
    }
}