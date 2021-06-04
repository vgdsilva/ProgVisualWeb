using ProgVisualWeb.Controller.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgVisualWeb.web.Categoria
{
    public partial class CadastroCategoria : System.Web.UI.Page
    {
        private string ChaveSessao = "S_CONTROLLER";
        private CategoriaBO ControllerCategoria
        {
            get
            {
                if (HttpContext.Current.Session[ChaveSessao] == null)
                    HttpContext.Current.Session[ChaveSessao] = new CategoriaBO();

                return HttpContext.Current.Session[ChaveSessao] as CategoriaBO;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback && !Page.IsPostBack)
                HttpContext.Current.Session[ChaveSessao] = null;
        }
    }
}