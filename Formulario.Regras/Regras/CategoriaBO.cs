//using Formulario.ConsoleApp;
using Formulario.DB;
using Formulario.Entidades.Entidades;
using Formulario.Regras.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Formulario.Regras.Regras
{
    public class CategoriaBO
    {
        Connection conexao = new Connection();
        private NextID idGenerator = new NextID();
        

        public List<Categoria> SelectCategorias()
        {
            string SelectCategoria = "SELECT * FROM categoria";
            DataTable dt = new DataTable();

            NpgsqlDataAdapter pgsqlAdt = new NpgsqlDataAdapter(SelectCategoria, conexao.Conectar());
            pgsqlAdt.Fill(dt);
            conexao.Desconectar();

            return ConvertDataTable(dt);
        }

        public List<Categoria> ConvertDataTable(DataTable dt)
        {
            List<Categoria> ListCategoria = new List<Categoria>();

            foreach (DataRow dataRow in dt.Rows)
                ListCategoria.Add(new Categoria
                {
                    IDCategoria = Convert.ToInt64(dataRow["idcategoria"]),
                    Codigo = Convert.ToInt64(dataRow["codigo"]),
                    Descricao = dataRow["descricao"].ToString()
                });

            return ListCategoria;
        }

        public bool InsertCategoria(Categoria categorias)
        {
            string InsertCategoria = "INSERT INTO categoria( idcategoria, codigo, descricao) VALUES(@idcategoria, @codigo, @descricao);";

            categorias.IDCategoria = idGenerator.GetNextID("idcategoria");

            NpgsqlCommand command = new NpgsqlCommand(InsertCategoria, conexao.Conectar());

            command.Parameters.AddWithValue("idcategoria", categorias.IDCategoria);
            command.Parameters.AddWithValue("codigo", categorias.Codigo);
            command.Parameters.AddWithValue("descricao", categorias.Descricao);

            int QntRegistros = command.ExecuteNonQuery();

            conexao.Desconectar();

            //new EnvioDeEmail().EnviarEmail("Adição de Categoria", $"Categoria com o id: {categorias.IDCategoria} foi Adicionado");
            return QntRegistros > 0;
        }

        public bool DeleteCategoria(long idCategoria)
        {
            string DeleteCategoria = "DELETE FROM categoria WHERE idcategoria = @idcategoria";

            NpgsqlCommand command = new NpgsqlCommand(DeleteCategoria, conexao.Conectar());

            command.Parameters.AddWithValue("@idcategoria", idCategoria);

            int RegistrosDelete = command.ExecuteNonQuery();

            conexao.Desconectar();

            //new EnvioDeEmail().EnviarEmail("Exclusão de Categoria", $"Categoria com o id: {idCategoria} foi excluido");
            return RegistrosDelete > 0;
        }

        public bool UpdateCategoria(Categoria categorias)
        {
            string UpdateCategoria = "UPDATE categoria SET codigo = @codigo, descricao = @descricao WHERE idcategoria = @idcategoria";

            NpgsqlCommand command = new NpgsqlCommand(UpdateCategoria, conexao.Conectar());

            command.Parameters.AddWithValue("idcategoria", categorias.IDCategoria);
            command.Parameters.AddWithValue("codigo", categorias.Codigo);
            command.Parameters.AddWithValue("descricao", categorias.Descricao);

            int QntRegistros = command.ExecuteNonQuery();

            conexao.Desconectar();

            //new EnvioDeEmail().EnviarEmail("Edição de Categoria", $"Categoria com o id: {categorias.IDCategoria} foi editado");
            return QntRegistros > 0;
        }
    }
}
