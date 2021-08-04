using Formulario.DB;
using Formulario.Entidades.Entidades;
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
    public class MarcaBO
    {

        Connection conexao = new Connection();
        private NextID idGenerator = new NextID();

        public List<Marcas> SelectMarcas()
        {
            string SelectMarca = "SELECT * FROM marca";
            DataTable dt = new DataTable();

            NpgsqlDataAdapter pgsqlAdt = new NpgsqlDataAdapter(SelectMarca, conexao.Conectar());
            pgsqlAdt.Fill(dt);
            conexao.Desconectar();

            return ConvertDataTableProdutos(dt);
        }

        public List<Marcas> ConvertDataTableProdutos(DataTable dt)
        {
            List<Marcas> ListMarca = new List<Marcas>();

            foreach (DataRow dataRow in dt.Rows)
                ListMarca.Add(new Marcas
                {
                    IDMarca = Convert.ToInt64(dataRow["idmarca"]),
                    Codigo = Convert.ToInt64(dataRow["codigo"]),
                    Descricao = dataRow["descricao"].ToString()
                });

            return ListMarca;
        }

        public bool InsertMarca(Marcas marca)
        {
            string InsertMarca = "INSERT INTO marca( idmarca, codigo, descricao) VALUES(@idmarca, @codigo, @descricao);";

            marca.IDMarca = idGenerator.GetNextID("idmarca");

            NpgsqlCommand command = new NpgsqlCommand(InsertMarca, conexao.Conectar());

            command.Parameters.AddWithValue("idmarca", marca.IDMarca);
            command.Parameters.AddWithValue("codigo", marca.Codigo);
            command.Parameters.AddWithValue("descricao", marca.Descricao);

            int QntRegistros = command.ExecuteNonQuery();

            conexao.Desconectar();

            return QntRegistros > 0;
        }

        public bool DeleteCategoria(long idCategoria)
        {
            string DeleteCategoria = "DELETE FROM categoria WHERE idmarca = @idmarca";

            NpgsqlCommand command = new NpgsqlCommand(DeleteCategoria, conexao.Conectar());

            command.Parameters.AddWithValue("@idmarca", idCategoria);

            int RegistrosDelete = command.ExecuteNonQuery();

            conexao.Desconectar();

            return RegistrosDelete > 0;
        }

        public bool EditarCategoria(Categoria categorias)
        {
            string UpdateCategoria = "UPDATE marca SET codigo = @codigo, descricao = @descricao WHERE idmarca = @idmarca";

            NpgsqlCommand command = new NpgsqlCommand(UpdateCategoria, conexao.Conectar());

            command.Parameters.AddWithValue("idmarca", categorias.IDCategoria);
            command.Parameters.AddWithValue("codigo", categorias.Codigo);
            command.Parameters.AddWithValue("descricao", categorias.Descricao);

            int QntRegistros = command.ExecuteNonQuery();

            conexao.Desconectar();

            return QntRegistros > 0;
        }
    }
}
