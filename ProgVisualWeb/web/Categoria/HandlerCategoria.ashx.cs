using ProgVisualWeb.Controller.Regras;
using ProgVisualWeb.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace ProgVisualWeb.web.Categoria
{
    /// <summary>
    /// Summary description for HandlerCategoria
    /// </summary>
    public class HandlerCategoria : IHttpHandler, IRequiresSessionState
    {
        private string ChaveSessao = "S_CONTROLLER_";

        private enum Acao
        {
            CONSULTAR = 0,
            ADICIONAR = 1,
            EDITAR = 2,
            EXCLUIR = 3,
            CONSULTARID = 4
        }

        private CategoriaBO ControllerCategoria
        {
            get
            {
                if (HttpContext.Current.Session[ChaveSessao] == null)
                    HttpContext.Current.Session[ChaveSessao] = new CategoriaBO();

                return HttpContext.Current.Session[ChaveSessao] as CategoriaBO;
            }
        }

        private void Consultar(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write(new JavaScriptSerializer().Serialize(new CategoriaBO().SelectTodasCategorias().ToArray()));
        }

        private bool Adicionar(HttpContext context)
        {
            string JsonCategoria = new StreamReader(context.Request.InputStream).ReadToEnd();
            Categorias categorias = new JavaScriptSerializer().Deserialize<Categorias>(JsonCategoria);

            return new CategoriaBO().InsertCategoria(categorias);
        }

        private void Editar()
        {

        }

        private bool Excluir(HttpContext context)
        {
            string categoria = new StreamReader(context.Request.InputStream).ReadToEnd();
            long idCategoria = Convert.ToInt64(categoria);

            return new CategoriaBO().DeleteCategoria(idCategoria);
        }

        private void ConsultarID()
        {

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
                    //context.Response.Write(Editar(context) ? "OK" : "ERRO");
                    break;
                case Acao.EXCLUIR:
                    Excluir(context);
                    break;
                case Acao.CONSULTARID:
                    //ConsultarID();
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