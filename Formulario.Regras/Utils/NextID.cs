using Formulario.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Regras.Utils
{
    public class NextID
    {

        public Connection conexao = new Connection();
        
        public long GetNextID(string id)
        {
            string SqlNextID = $"SELECT NEXTVAL('{id}');";
            DataTable dt = new DataTable();

            NpgsqlDataAdapter AdptID = new NpgsqlDataAdapter(SqlNextID, conexao.Conectar());
            conexao.Conectar();

            AdptID.Fill(dt);

            return Convert.ToInt64(dt.Rows[0][0]);
        }
    }
}
