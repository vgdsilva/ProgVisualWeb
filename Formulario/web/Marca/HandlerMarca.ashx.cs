using Formulario.Regras.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Formulario.web.Marca
{
    /// <summary>
    /// Descrição resumida de HandlerMarca
    /// </summary>
    public class HandlerMarca : IHttpHandler, IRequiresSessionState
    {

        private string ChaveSessao = "S_CONTROLLER_MARCA";
        private enum Acao
        {
            CONSULTAR = 0,
            ADICIONAR = 1,
            EDITAR = 2,
            EXCLUIR = 3
        }

        private MarcaBO ControllerProduto
        {
            get
            {
                if (HttpContext.Current.Session[ChaveSessao] == null)
                    HttpContext.Current.Session[ChaveSessao] = new MarcaBO();

                return HttpContext.Current.Session[ChaveSessao] as MarcaBO;
            }
        }


        private void Consultar(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write(new JavaScriptSerializer().Serialize(new MarcaBO().SelectMarcas().ToArray()));
        }

        private bool Adicionar(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private bool Editar(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private bool Excluir(HttpContext context)
        {
            throw new NotImplementedException();
        }


        public void ProcessRequest(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.QueryString["acao"]))
                return;

            switch (Enum.Parse(typeof(Acao), context.Request.QueryString["acao"]))
            {
                case Acao.CONSULTAR:
                    Consultar(context);
                    break;
                case Acao.ADICIONAR:
                    context.Response.Write(Adicionar(context).ToString());
                    break;
                case Acao.EDITAR:
                    context.Response.Write(Editar(context) ? "OK" : "ERRO");
                    break;
                case Acao.EXCLUIR:
                    Excluir(context);
                    break;
            }
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