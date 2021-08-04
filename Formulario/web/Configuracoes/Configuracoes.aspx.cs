using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario.web.Configuracoes
{
    public partial class Configuracoes : System.Web.UI.Page
    {
        private string ChaveSessao = "S_CONTROLLER_CONFIGURACOES";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback && !Page.IsPostBack)
                HttpContext.Current.Session[ChaveSessao] = null;
        }
    }
}