using System;
using System.Data;
using System.Data.SqlClient;

namespace Parser_for_AutoAll.Core.SQL
{
    class ConnectionToDB
    {
        private readonly string sqlParams = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Proger1\source\repos\Parser-for-AutoAll\Parts.mdf;User ID=UserAdmin;Password=Lorgar17";
        public SqlConnection sqlConnection;
        
        public void OpenConnection() 
        {
            sqlConnection = new SqlConnection(sqlParams);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                Console.WriteLine("Подключение к базе установлено.");
            }
        }
    }
}

