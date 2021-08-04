using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace Formulario.DB
{
    public class Connection
    {

        public static string strConn = "Server=127.0.0.1;" +
                                        "Port=5432;" +
                                        "Database=cmdb_progvisual;" +
                                        "User Id=postgres;" +
                                        "Password=123;";

        public static NpgsqlConnection pgsqlConnection = new NpgsqlConnection(strConn);


        public NpgsqlConnection Conectar()
        {
            try
            {
                if (pgsqlConnection.State == ConnectionState.Closed)
                    pgsqlConnection.Open();

                return pgsqlConnection;
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw new Exception(erro);

            }
        }

        public void Desconectar()
        {
            if (pgsqlConnection.State == ConnectionState.Open)
                pgsqlConnection.Close();

        }

    }
}
