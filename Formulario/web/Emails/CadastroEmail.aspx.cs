using Formulario.Regras.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario.web.Emails
{
    public partial class CadastroEmail : System.Web.UI.Page
    {
        private string ChaveSessao = "S_CONTROLLER_EMAIL";

        private EnviarEmail ControllerEmail
        {
            get
            {
                if (HttpContext.Current.Session[ChaveSessao] == null)
                    HttpContext.Current.Session[ChaveSessao] = new EnviarEmail();

                return HttpContext.Current.Session[ChaveSessao] as EnviarEmail;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback && !Page.IsPostBack)
                HttpContext.Current.Session[ChaveSessao] = null;
        }
    }
}