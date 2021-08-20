using Newtonsoft.Json;
using Parser_for_AutoAll.Core.Parser;
using System;
using System.Collections.Generic;
using System.IO;

namespace Parser_for_AutoAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var load = new PictureLoader();
            load.Loader();
            

            Console.ReadKey();
        }
    }
}
