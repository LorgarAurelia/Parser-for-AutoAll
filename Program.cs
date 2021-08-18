using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parser_for_AutoAll.Core.Parser;

namespace Parser_for_AutoAll
{
    class DataToTransfer 
    {
        public List<string> name;
        public List<string> aricle;
        public List<string> orderCode;
        public List<string> vendor;
        public List<string> price;

    }
    class Program
    {
        static void Main(string[] args)
        {
            
            var parser = new HtmlParser();
            DataToTransfer data = new DataToTransfer();
            parser.ParseHtml();

            for (int i = 0; i < parser.name.Count; i++)
            {
                Console.WriteLine("Название позиции: " + parser.name[i]);
                Console.WriteLine("Артикул:" + parser.article[i]);
                Console.WriteLine("Код заказа "+parser.orderCode[i]);
                Console.WriteLine("Производитель:"+ parser.vendor[i]);
                Console.WriteLine("Цена:\t" + parser.price[i]);
            }

            data.name = parser.name;
            data.aricle = parser.article;
            data.orderCode = parser.orderCode;
            data.vendor = parser.vendor;
            data.price = parser.price;

            string json = JsonConvert.SerializeObject(data);

            Console.ReadKey();
        }
    }
}
