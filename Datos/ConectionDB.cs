using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public sealed class ConectionDB
    {
        private ConectionDB() { }

        private readonly static SqlConnection conn = new SqlConnection();

        public static SqlConnection Instance
        {
            get
            {
                if (conn.State == ConnectionState.Closed) OpenConnection();

                return conn;
            }
        }

        public static void OpenConnection()
        {
            try
            {
                conn.ConnectionString = "Data Source=DESKTOP-M5BV3EC;Initial Catalog=sistema_matriculacion;Trusted_Connection=True";
                conn.Open();
            }
            catch (SqlException)
            {
                Console.WriteLine("Error al abrir la conexión.");
            }
        }

        public static void CloseConnection()
        {
            try
            {
                conn.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("Error al cerrar la conexión.");
            }
        }
    }
}
