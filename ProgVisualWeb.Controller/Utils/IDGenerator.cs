using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ProgVisualWeb.DAO;

namespace ProgVisualWeb.Controller.Utils
{
    public class IDGenerator
    {
        public Connection objConexao = new Connection();
        public long GetNextID(string id)
        {
            string SqlNextID = $"SELECT NEXTVAL('{id}');";
            DataTable dt = new DataTable();

            NpgsqlDataAdapter AdptID = new NpgsqlDataAdapter(SqlNextID, Connection.pgsqlConnection);
            objConexao.Conectar();

            AdptID.Fill(dt);

            return Convert.ToInt64(dt.Rows[0][0]);
        }


    }
}
