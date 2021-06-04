using Npgsql;
using ProgVisualWeb.Controller.Utils;
using ProgVisualWeb.DAO;
using ProgVisualWeb.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVisualWeb.Controller.Regras
{
    public class CategoriaBO
    {
        private Connection objConexao = new Connection();
        private IDGenerator idGenerator = new IDGenerator();
        private NpgsqlDataAdapter pgsqlAdt = null;
        private NpgsqlCommand command = null;
        

        #region Select

        /// <summary>
        /// Função para selecionar todas minha categorias
        /// </summary>
        /// <returns></returns>
        public List<Categorias> SelectTodasCategorias()
        {
            string SelectCategoria = "SELECT * FROM CATEGORIA";

            DataTable dtt = new DataTable();

            pgsqlAdt = new NpgsqlDataAdapter(SelectCategoria, Connection.pgsqlConnection);
            objConexao.Conectar();

            pgsqlAdt.Fill(dtt);

            objConexao.Desconectar();

            return ConvertDataTableProdutos(dtt);

        }

        private List<Categorias> ConvertDataTableProdutos(DataTable dt)
        {
            List<Categorias> ListCategoria = new List<Categorias>();

            foreach (DataRow dataRow in dt.Rows)
                ListCategoria.Add(new Categorias
                {
                    IDCategoria = Convert.ToInt64(dataRow["IDCATEGORIA"]),
                    Codigo = Convert.ToInt64(dataRow["CODIGO"]),
                    Descricao = dataRow["DESCRICAO"].ToString()
                });

            return ListCategoria;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Função para inserir dados na tabela
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public bool InsertCategoria(Categorias categoria)
        {
            string insert = "INSERT INTO categoria (idcategoria, codigo, descricao) VALUES(@idcategoria, @codigo, @descricao);";
            categoria.IDCategoria = idGenerator.GetNextID("IDCATEGORIA");

            command = new NpgsqlCommand(insert, Connection.pgsqlConnection);
            objConexao.Conectar();

            command.Parameters.AddWithValue("@idcategoria", categoria.IDCategoria);
            command.Parameters.AddWithValue("@codigo", categoria.Codigo);
            command.Parameters.AddWithValue("@descricao", categoria.Descricao);

            int QntRegistros = command.ExecuteNonQuery();

            objConexao.Desconectar();

            return QntRegistros > 0;
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        public bool DeleteCategoria(long idCategoria)
        {
            string delete = "DELETE FROM categoria WHERE idcategoria = @idcategoria; ";

            command = new NpgsqlCommand(delete, Connection.pgsqlConnection);
            objConexao.Conectar();

            command.Parameters.AddWithValue("@idcategoria", idCategoria);

            int QntRegistro = command.ExecuteNonQuery();

            objConexao.Desconectar();

            return QntRegistro > 0;
        }

        #endregion
    }
}
