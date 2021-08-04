using Formulario.Entidades.Entidades;
using Formulario.Regras.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Formulario.web.Emails
{
    /// <summary>
    /// Descrição resumida de HandlerEmail
    /// </summary>
    public class HandlerEmail : IHttpHandler, IRequiresSessionState
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

        public void ProcessRequest(HttpContext context)
        {
            string JsonEmail = new StreamReader(context.Request.InputStream).ReadToEnd();
            Email email = new JavaScriptSerializer().Deserialize<Email>(JsonEmail);

            string assunto = email.Assunto;
            string destinatario = email.Destinatario;
            string mensagem = email.Mensagem;

            new EnviarEmail().SendEmail(assunto, destinatario, mensagem);
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