using Formulario.Regras.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario.web.Marca
{
    public partial class CadastroMarca : Page
    {
        private string ChaveSessao = "S_CONTROLLER_MARCA";

        private MarcaBO ControllerProduto
        {
            get
            {
                if (HttpContext.Current.Session[ChaveSessao] == null)
                    HttpContext.Current.Session[ChaveSessao] = new MarcaBO();

                return HttpContext.Current.Session[ChaveSessao] as MarcaBO;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback && !Page.IsPostBack)
                HttpContext.Current.Session[ChaveSessao] = null;

            
        }
    }
}