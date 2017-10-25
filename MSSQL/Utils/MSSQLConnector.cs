using System;
using System.Data.SqlClient;

namespace MSSQL.Utils
{
    class MSSQLConnector
    {
        private readonly string instance;
        private readonly string database;
        private readonly string username;
        private readonly string password;

        public MSSQLConnector(string instance, string database, string username, string password)
        {
            if (string.IsNullOrEmpty(instance) ||
                string.IsNullOrEmpty(database) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("MSSQLConnector exception: one of the parameters is invalid (null or empty)");
            }

            this.instance = instance;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        public bool Connect(out string message)
        {
            string connectionString = string.Format("Server={0};Database={1};User ID={2};Password={3}", instance, database, username, password);

            SqlConnection connection = new SqlConnection(connectionString);
            bool isConnected = false;
            try
            {
                connection.Open();
                message = "The connection is open";
                isConnected = true;
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return isConnected;
        }
    }
}
