using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Parser_for_AutoAll.Core.SQL
{
    class ConnectionToDB
    {
        private readonly string sqlParams = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Study\Parser for AutoAll\AutoPatrs.mdf';User ID=AdminUser;Password=Lorgar17";
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
