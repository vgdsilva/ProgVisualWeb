using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Formulario.web.Configuracoes
{
    /// <summary>
    /// Descrição resumida de HandlerConfiguracoes
    /// </summary>
    public class HandlerConfiguracoes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Olá, Mundo");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}