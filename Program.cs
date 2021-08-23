using Newtonsoft.Json;
using Parser_for_AutoAll.Core.Parser;
using Parser_for_AutoAll.Core.SQL;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Parser_for_AutoAll
{
    class Program
    {
        static void Main(string[] args)
        {

            /*var connect = new ConnectionToDB();
            connect.OpenConnection();*/
            var inserter = new InsertIntoDB();
            inserter.Insert();



            Console.ReadKey();
        }
    }
}
