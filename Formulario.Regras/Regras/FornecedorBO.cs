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
    public class FornecedorBO
    {
        Connection conexao = new Connection();
        private NextID idGenerator = new NextID();

        public List<Fornecedor> SelectFornecedores()
        {
            string SelectFornecedor = "select * from fornecedor";
            DataTable dt = new DataTable();

            NpgsqlDataAdapter pgsqlAdt = new NpgsqlDataAdapter(SelectFornecedor, conexao.Conectar());
            pgsqlAdt.Fill(dt);
            conexao.Desconectar();

            return ConvertDataTable(dt);
        }

        public List<Fornecedor> ConvertDataTable(DataTable dt)
        {
            List<Fornecedor> ListFornecedores = new List<Fornecedor>();

            foreach (DataRow dataRow in dt.Rows)
                ListFornecedores.Add(new Fornecedor
                {
                    IDFornecedor = Convert.ToInt64(dataRow["idfornecedor"]),
                    Codigo = Convert.ToInt64(dataRow["codigo"]),
                    Descricao = dataRow["descricao"].ToString()
                });

            return ListFornecedores;
        }

    }
}
