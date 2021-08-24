using Parser_for_AutoAll.Core.Parser;
using System;
using System.Data.SqlClient;

namespace Parser_for_AutoAll.Core.SQL
{
    class InsertIntoDB : ConnectionToDB
    {
        private readonly ErrorMessages errors = new();
        public void Insert() 
        {
            var parse = new PictureLoader();
            parse.Loader();

            var connection = new ConnectionToDB();
            connection.OpenConnection();
            string query;

            for (int i = 0; i < parse.parsedData.savedData.Name.Count; i++)
            {
                if (parse.parsedData.savedData.Name[i] == errors.badValue || parse.parsedData.savedData.Article[i] == errors.badValue || parse.parsedData.savedData.OrderCode[i] == errors.badValue || parse.parsedData.savedData.Vendor[i] == errors.badValue || parse.parsedData.savedData.Price[i] == errors.badValue)
                {
                    continue;
                }
                query = "INSERT INTO [Parts] (name, article, orderCode, vendor, price, pathToPicture) VALUES (N'" + parse.parsedData.savedData.Name[i] + "', N'" + parse.parsedData.savedData.Article[i] + "', N'" + parse.parsedData.savedData.OrderCode[i] + "', N'" + parse.parsedData.savedData.Vendor[i] + "', N'" + parse.parsedData.savedData.Price[i] + "', N'" + parse.parsedData.savedData.PathToSavedPicture[i] + "')";

                SqlCommand command = new SqlCommand(query, connection.sqlConnection);
                command.ExecuteNonQuery();
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
