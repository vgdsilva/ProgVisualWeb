using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgVisualWeb.DAO;
using ProgVisualWeb.Entities.Entidades;
using Npgsql;
using System.Data;
using ProgVisualWeb.Controller.Utils;

namespace ProgVisualWeb.Controller.Regras
{
    public class ProdutoBO
    {
        private Connection objConexao = new Connection();
        private IDGenerator idGenerator = new IDGenerator(); 
        
        /// <summary>
        /// Função para selecionar todos produtos
        /// </summary>
        /// <returns></returns>
        public List<Produtos> SelectTodosProdutos()
        {
            string SqlSelectProduto = "SELECT * FROM PRODUTO;";
            DataTable dtt = new DataTable();

            NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(SqlSelectProduto, objConexao.Conectar());
          
            Adpt.Fill(dtt);
            objConexao.Desconectar();

            return ConvertDataTableProdutos(dtt);

        }

        /// <summary>
        /// Função para adicionar um produto
        /// </summary>
        /// <param name="pProduto">Produto que sera adicionado</param>
        /// <returns></returns>
        public bool InsertProduto(Produtos pProduto)
        {
            string SqlInsertProduto = "INSERT INTO PRODUTO(idproduto, codigo, codigobarras, descricao, preco, idcategoria, fornecedor, marca) " +
            "VALUES(@idproduto, @codigo, @codigobarras, @descricao, @preco, @idcategoria, @fornecedor, @marca);";

            pProduto.IDProduto = idGenerator.GetNextID("IDPRODUTO");

            NpgsqlCommand command = new NpgsqlCommand(SqlInsertProduto, objConexao.Conectar());            

            command.Parameters.AddWithValue("@idproduto", pProduto.IDProduto);
            command.Parameters.AddWithValue("@codigo", pProduto.Codigo);
            command.Parameters.AddWithValue("@codigobarras", pProduto.CodigoBarras);
            command.Parameters.AddWithValue("@descricao", pProduto.IDProduto);
            command.Parameters.AddWithValue("@preco", pProduto.Preco);
            command.Parameters.AddWithValue("@idcategoria", pProduto.IDCategoria);
            command.Parameters.AddWithValue("@fornecedor", pProduto.Fornecedor);
            command.Parameters.AddWithValue("@marca", pProduto.Marca);

            int QntRegistros = command.ExecuteNonQuery();

            objConexao.Desconectar();

            return QntRegistros > 0;
        }

        public bool UpdateProduto(Produtos pProduto)
        {
            string SqlUpdateProduto = "UPDATE PRODUTO SET CODIGO = @CODIGO, CODIGOBARRAS = @CODIGOBARRAS, DESCRICAO = @DESCRICAO, " +
                "PRECO = @PRECO, IDCATEGORIA = @IDCATEGORIA, FORNECEDOR = @FORNECEDOR, MARCA = @MARCA WHERE IDPRODUTO = @IDPRODUTO";

            NpgsqlCommand command = new NpgsqlCommand(SqlUpdateProduto, objConexao.Conectar());

            command.Parameters.AddWithValue("@IDPRODUTO", pProduto.IDProduto);
            command.Parameters.AddWithValue("@CODIGO", pProduto.Codigo);
            command.Parameters.AddWithValue("@CODIGOBARRAS", pProduto.CodigoBarras);
            command.Parameters.AddWithValue("@DESCRICAO", pProduto.Descricao);
            command.Parameters.AddWithValue("@PRECO", pProduto.Preco);
            command.Parameters.AddWithValue("@IDCATEGORIA", pProduto.IDCategoria);
            command.Parameters.AddWithValue("@FORNECEDOR", pProduto.Fornecedor);
            command.Parameters.AddWithValue("@MARCA", pProduto.Marca);

            int QntRegistros = command.ExecuteNonQuery();

            objConexao.Desconectar();

            return QntRegistros > 0;

        }

        /// <summary>
        /// Função para deletar um produto
        /// </summary>
        /// <param name="pIdproduto">Id do produto</param>
        public void DeleteProduto(long pIdproduto)
        {
            string SqlDeleteProduto = "DELETE FROM PRODUTO WHERE IDPRODUTO = @IDPRODUTO;";
            
            NpgsqlCommand command = new NpgsqlCommand(SqlDeleteProduto, objConexao.Conectar());

            command.Parameters.AddWithValue("@IDPRODUTO", pIdproduto);

            var delete = command.ExecuteNonQuery();

            objConexao.Desconectar();

        }

        /// <summary>
        /// função para converter uma datatable em uma lista
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Produtos> ConvertDataTableProdutos(DataTable dt)
        {
            List<Produtos> ListProduto = new List<Produtos>();

            foreach (DataRow dataRow in dt.Rows)
                ListProduto.Add(new Produtos
                {
                    IDProduto = Convert.ToInt64(dataRow["IDPRODUTO"]),
                    Codigo = Convert.ToInt64(dataRow["CODIGO"]),
                    CodigoBarras = dataRow["CODIGOBARRAS"].ToString(),
                    Descricao = dataRow["DESCRICAO"].ToString(),
                    Preco = Convert.ToDecimal(dataRow["PRECO"]),
                    IDCategoria = Convert.ToInt64(dataRow["IDCATEGORIA"]),
                    Fornecedor = dataRow["FORNECEDOR"].ToString(),
                    Marca = dataRow["MARCA"].ToString()
                });

            return ListProduto;
        }
    }
}
