using Parser_for_AutoAll.Core.Parser;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Parser_for_AutoAll.Core.SQL
{
    class ConnectionToDB
    {
        private readonly string sqlParams = NetworkParamaters.sqlConnection;

        public SqlConnection sqlConnection;
        
        public ConnectionToDB() 
        {
            sqlConnection = new SqlConnection(sqlParams);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
                Console.WriteLine("Connection opened.");
        }
        ~ConnectionToDB() 
        {
            sqlConnection.Close();
            if (sqlConnection.State == ConnectionState.Closed)
                Console.WriteLine("Connection closed");
        }
    }
}

