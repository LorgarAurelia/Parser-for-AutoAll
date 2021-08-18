using System;
using System.Collections.Generic;
using Parser_for_AutoAll.Core.Parser;

namespace Parser_for_AutoAll
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var parser = new HtmlParser();
            parser.ParseHtml();

            for (int i = 0; i < parser.name.Count; i++)
            {
                Console.WriteLine("Название позиции: " + parser.name[i]);
                Console.WriteLine("Артикул:" + parser.article[i]);
                Console.WriteLine("Код заказа "+parser.orderCode[i]);
                Console.WriteLine("Производитель:"+ parser.vendor[i]);
                Console.WriteLine("Цена:\t" + parser.price[i]);
            }
        }
    }
}
