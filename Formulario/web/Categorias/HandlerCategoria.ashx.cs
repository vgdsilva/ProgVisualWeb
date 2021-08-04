using Formulario.Entidades.Entidades;
using Formulario.Regras.Regras;
using Formulario.Regras.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Formulario.web.Categorias
{
    /// <summary>
    /// Descrição resumida de HandlerCategoria
    /// </summary>
    public class HandlerCategoria : IHttpHandler, IRequiresSessionState
    {

        private string ChaveSessao = "S_CONTROLLER_CATEGORIA";

        private enum Acao
        {
            CONSULTAR = 0,
            ADICIONAR = 1,
            EDITAR = 2,
            EXCLUIR = 3,
            NEXTID = 4
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
            context.Response.Write(new JavaScriptSerializer().Serialize(new CategoriaBO().SelectCategorias().ToArray()));
        }

        private bool Adicionar(HttpContext context)
        {
            string JsonCategoria = new StreamReader(context.Request.InputStream).ReadToEnd();
            Categoria categorias = new JavaScriptSerializer().Deserialize<Categoria>(JsonCategoria);

            
            return new CategoriaBO().InsertCategoria(categorias);
        }

        private bool Editar(HttpContext context)
        {
            string JsonCategoria = new StreamReader(context.Request.InputStream).ReadToEnd();
            Categoria categorias = new JavaScriptSerializer().Deserialize<Categoria>(JsonCategoria);

            
            return new CategoriaBO().UpdateCategoria(categorias);
        }

        private bool Excluir(HttpContext context)
        {
            string categoria = new StreamReader(context.Request.InputStream).ReadToEnd();
            long idCategoria = Convert.ToInt64(categoria);

            
            return new CategoriaBO().DeleteCategoria(idCategoria);
        }

        private void NextID(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write(new JavaScriptSerializer().Serialize(new NextID().GetNextID("idcategoria")).ToArray());
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
                case Acao.NEXTID:
                    NextID(context);
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