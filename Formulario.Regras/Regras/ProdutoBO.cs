using Formulario.DB;
using Formulario.Models.Entidades;
using Formulario.Regras.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Regras.Regras
{
    public class ProdutoBO
    {
        private Connection conexao = new Connection();
        private NextID idGenerator = new NextID();
        private EnviarEmail email = new EnviarEmail();

        public List<Produto> SelectTodosProdutos()
        {
            string SqlSelectProduto = "SELECT * FROM PRODUTO";
            DataTable dtt = new DataTable();

            NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(SqlSelectProduto, conexao.Conectar());
            Adpt.Fill(dtt);
            conexao.Desconectar();

            return ConvertDataTableProdutos(dtt);
        }

        public List<Produto> ConvertDataTableProdutos(DataTable dt)
        {
            List<Produto> ListProduto = new List<Produto>();

            foreach (DataRow dataRow in dt.Rows)
                ListProduto.Add(new Produto
                {
                    IDProduto = Convert.ToInt64(dataRow["idproduto"]),
                    Codigo = Convert.ToInt64(dataRow["codigo"]),
                    CodigoBarras = dataRow["codigobarras"].ToString(),
                    Descricao = dataRow["descricao"].ToString(),
                    Preco = Convert.ToDecimal(dataRow["preco"]),
                    IDCategoria = Convert.ToInt64(dataRow["idcategoria"]),
                    IDFornecedor = Convert.ToInt64(dataRow["idfornecedor"]),
                    IDMarca = Convert.ToInt64(dataRow["idmarca"])
                });

            return ListProduto;
        }

        public bool InsertProduto(Produto produto)
        {
            string SqlInsertProduto = "INSERT INTO PRODUTO(idproduto, codigo, codigobarras, descricao, preco, idcategoria, idfornecedor, idmarca) " +
            "VALUES(@idproduto, @codigo, @codigobarras, @descricao, @preco, @idcategoria, @idfornecedor, @idmarca);";

            produto.IDProduto = idGenerator.GetNextID("idproduto");

            NpgsqlCommand command = new NpgsqlCommand(SqlInsertProduto, conexao.Conectar());

            command.Parameters.AddWithValue("idproduto", produto.IDProduto);
            command.Parameters.AddWithValue("codigo", produto.Codigo);
            command.Parameters.AddWithValue("codigobarras", produto.CodigoBarras);
            command.Parameters.AddWithValue("descricao", produto.Descricao);
            command.Parameters.AddWithValue("preco", produto.Preco);
            command.Parameters.AddWithValue("idcategoria", produto.IDCategoria);
            command.Parameters.AddWithValue("idfornecedor", produto.IDFornecedor);
            command.Parameters.AddWithValue("idmarca", produto.IDMarca);

            int QntRegistros = command.ExecuteNonQuery();

            conexao.Desconectar();

            return QntRegistros > 0 ;
        }

        public bool UpdateProduto(Produto produto)
        {
            string SqlUpdateProduto = "UPDATE PRODUTO SET CODIGO = @CODIGO, CODIGOBARRAS = @CODIGOBARRAS, DESCRICAO = @DESCRICAO, " +
                "PRECO = @PRECO, IDCATEGORIA = @IDCATEGORIA, IDFORNECEDOR = @IDFORNECEDOR, IDMARCA = @IDMARCA WHERE IDPRODUTO = @IDPRODUTO";

            NpgsqlCommand command = new NpgsqlCommand(SqlUpdateProduto, conexao.Conectar());

            command.Parameters.AddWithValue("@IDPRODUTO", produto.IDProduto);
            command.Parameters.AddWithValue("@CODIGO", produto.Codigo);
            command.Parameters.AddWithValue("@CODIGOBARRAS", produto.CodigoBarras);
            command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            command.Parameters.AddWithValue("@PRECO", produto.Preco);
            command.Parameters.AddWithValue("@IDCATEGORIA", produto.IDCategoria);
            command.Parameters.AddWithValue("@IDFORNECEDOR", produto.IDFornecedor);
            command.Parameters.AddWithValue("@IDMARCA", produto.IDMarca);

            int QntRegistros = command.ExecuteNonQuery();

            conexao.Desconectar();

            return QntRegistros > 0;
        }

        public bool DeleteProduto(long id)
        {
            string SqlDeleteProduto = "DELETE FROM PRODUTO WHERE IDPRODUTO = @IDPRODUTO;";

            NpgsqlCommand command = new NpgsqlCommand(SqlDeleteProduto, conexao.Conectar());

            command.Parameters.AddWithValue("@IDPRODUTO", id);

            int itensDeletados = command.ExecuteNonQuery();

            conexao.Desconectar();

            //new Program().EnviarEmail("Excluo de Produto", $"Produto com o {id} foi excluido", "gasparellovinicius@gmail.com");
            return itensDeletados > 0;
        }
    }
}
