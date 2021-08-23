using Parser_for_AutoAll.Core.SQL;
using System;


namespace Parser_for_AutoAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var inserter = new InsertIntoDB();
            inserter.Insert();

            Console.WriteLine("Нажмите любую клавишу для завершения программы.");
            Console.ReadKey();
        }
    }
}
