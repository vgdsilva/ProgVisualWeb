using Formulario.Regras.Regras;
using Formulario.Regras.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario.web.Categorias
{
    public partial class CadastroCategoria : System.Web.UI.Page
    {

        private string ChaveSessao = "S_CONTROLLER_CATEGORIA";

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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object NextIDCategoria(string idcategoria)
        {
            return new NextID().GetNextID(idcategoria);
        }
    }
}