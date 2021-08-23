using Parser_for_AutoAll.Core.Parser;
using System;
using System.Data.SqlClient;

namespace Parser_for_AutoAll.Core.SQL
{
    class InsertIntoDB : ConnectionToDB
    {
        public void Insert() 
        {
            var parse = new PictureLoader();
            parse.Loader();

            var connection = new ConnectionToDB();
            connection.OpenConnection();
            string query;

            for (int i = 0; i < parse.systemData.data.Name.Count; i++)
            {
                query = "INSERT INTO [Parts] (name, article, orderCode, vendor, price, pathToPicture) VALUES (N'" + parse.systemData.data.Name[i] + "', N'" + parse.systemData.data.Aricle[i] + "', N'" + parse.systemData.data.OrderCode[i] + "', N'" + parse.systemData.data.Vendor[i] + "', N'" + parse.systemData.data.Price[i] + "', N'" + parse.systemData.data.PathToSavedPicture[i] + "')";

                SqlCommand command = new SqlCommand(query, connection.sqlConnection);
            }

            query = "SELECT * FROM Parts";
            SqlCommand commandOutput = new SqlCommand(query, connection.sqlConnection);
            SqlDataReader reader = commandOutput.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Id = {reader[0]} \n name = {reader[1]} \n article = {reader[2]}\n orderCode = {reader[3]} {reader[4]}\n price = {reader[5]}\n pathToPicture = {reader[6]}");
            }
        }
    }
}
