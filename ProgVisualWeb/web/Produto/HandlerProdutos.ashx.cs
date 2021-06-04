using ProgVisualWeb.Controller.Regras;
using ProgVisualWeb.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace ProgVisualWeb.web.Produto
{
    /// <summary>
    /// Summary description for HandlerProdutos
    /// </summary>
    public class HandlerProdutos : IHttpHandler, IRequiresSessionState
    {
        private string ChaveSessao = "S_CONTROLLER";
        private enum Acao
        {
            CONSULTAR = 0,
            ADICIONAR = 1,
            EDITAR = 2,
            EXCLUIR = 3
        }

        private ProdutoBO ControllerProduto
        {
            get
            {
                if (HttpContext.Current.Session[ChaveSessao] == null)
                    HttpContext.Current.Session[ChaveSessao] = new ProdutoBO();

                return HttpContext.Current.Session[ChaveSessao] as ProdutoBO;
            }
        }

        private void Consultar(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write(new JavaScriptSerializer().Serialize(new ProdutoBO().SelectTodosProdutos().ToArray()));
        }

        private bool Adicionar(HttpContext context)
        {
            string JsonProuto = new StreamReader(context.Request.InputStream).ReadToEnd();
            Produtos produto = new JavaScriptSerializer().Deserialize<Produtos>(JsonProuto);

            //Validações do backend

            return new ProdutoBO().InsertProduto(produto);
        }

        private bool Editar(HttpContext context)
        {
            string JsonProuto = new StreamReader(context.Request.InputStream).ReadToEnd();
            Produtos produto = new JavaScriptSerializer().Deserialize<Produtos>(JsonProuto);

            //Validações do backend

            return new ProdutoBO().UpdateProduto(produto);
        }

        private void Excluir(HttpContext context)
        {
            string idproduto = new StreamReader(context.Request.InputStream).ReadToEnd();
            long id = Convert.ToInt32(idproduto);
           
            new ProdutoBO().DeleteProduto(id);
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