using Parser_for_AutoAll.Core.Parser;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parser_for_AutoAll.Core.SQL
{
    class SqlService
    {
        public static void Insert(List<SystemisedData> dataTable) 
        {
            var connection = new ConnectionToDB();
            string query;

            foreach (SystemisedData row in dataTable)
            {
                 
                 if (Equals(row.Name,ErrorMessages.badValue) || Equals(row.Article,ErrorMessages.badValue) || Equals(row.OrderCode,ErrorMessages.badValue) || Equals(row.Vendor, ErrorMessages.badValue) || Equals(row.Price, ErrorMessages.badValue))
                 {
                     continue;
                 }
                
                
                query = $"INSERT INTO [Parts] (name, article, orderCode, vendor, price, pathToPicture) VALUES (N'{row.Name}', N'{row.Article}', N'{row.OrderCode}', N'{row.Vendor}', N'{row.Price}', N'{row.PathToSavedPicture}')";

                SqlCommand command = new(query, connection.sqlConnection);
                command.ExecuteNonQuery();
            }
        }

        public static List<SystemisedData> GetAll() 
        {
            var connection = new ConnectionToDB();

            List<SystemisedData> response = new();

            string query = "SELECT * FROM Parts";

            SqlCommand command = new(query, connection.sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SystemisedData currentRow = new();

                currentRow.Name = reader[1].ToString();
                currentRow.Article = reader[2].ToString();
                currentRow.OrderCode = reader[3].ToString();
                currentRow.Vendor = reader[4].ToString();
                currentRow.Price = reader[5].ToString();
                currentRow.PathToSavedPicture = reader[6].ToString();

                response.Add(currentRow);
            }

            return response;
        }
    }
}
