using Parser_for_AutoAll.Core.Parser;
using Parser_for_AutoAll.Core.SQL;
using System;
using System.Collections.Generic;

namespace Parser_for_AutoAll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SystemisedData> parsedData = HtmlParser.ParseHtml();

            List<SystemisedData> responseFromDB = new();

            SqlService.Insert(parsedData);

            responseFromDB = SqlService.GetAll();

            foreach (var row in responseFromDB)
            {
                Console.WriteLine($"Name: {row.Name}\n" +
                    $"Article: {row.OrderCode}\n" +
                    $"Order: {row.Price}\n" +
                    $"Vendor: {row.Vendor}\n" +
                    $"Price: {row.Price}\n" +
                    $"Path to picture: {row.PathToSavedPicture}\n");
            }

            Console.WriteLine("Нажмите любую клавишу для завершения программы.");
            Console.ReadKey();
        }
    }
}
