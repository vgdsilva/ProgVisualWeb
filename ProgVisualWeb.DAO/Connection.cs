using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ProgVisualWeb.DAO
{
    public class Connection
    {
        /// <summary>
        /// String de conexão com o banco de dados
        /// </summary>
        public static string strConn = "Server=127.0.0.1;Port=5432;Database=ProgVisual;User Id=postgres;Password=123;";
        
        /// <summary>
        /// Instancia de conexão com o banco de dados
        /// </summary>
        public static NpgsqlConnection pgsqlConnection = new NpgsqlConnection(strConn);

        /// <summary>
        /// Função para abrir conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public NpgsqlConnection Conectar()
        {
            try
            {
                if (pgsqlConnection.State == System.Data.ConnectionState.Closed)
                    pgsqlConnection.Open();

                return pgsqlConnection;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel se conectar com o banco de dados!");
            }
        }

        /// <summary>
        /// Função para desconectar com o banco de dados
        /// </summary>
        public void Desconectar()
        {
            if (pgsqlConnection.State == System.Data.ConnectionState.Open)
                pgsqlConnection.Clone();

        }

    }
}
