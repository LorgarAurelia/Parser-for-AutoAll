using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_for_AutoAll.Core.Parser
{
    class HtmlParser : WebClient
    {
        private string errorOfEmptyTable = "Пришла пустая таблица";
        private string errorOfEmptyHtml = "Пришёл пустой HTML";

        public List<string> name = new List<string>();
        public List<string> article = new List<string>();
        public List<string> orderCode = new List<string>();
        public List<string> vendor = new List<string>();
        public List<string> price = new List<string>();
        public void ParseHtml() 
        {
            var html = ConnectionToSite();

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            if (!string.IsNullOrEmpty(html))
                document.LoadHtml(html);
            else 
            { 
                Console.WriteLine(errorOfEmptyHtml);
                Environment.Exit(0);
            }

            var tables = document.DocumentNode.SelectNodes(".//div[@class='list-compact']//div[@class='item item-elem']");
            if (tables == null)
            {
                Console.WriteLine(errorOfEmptyTable);
                Environment.Exit(0);
            }

            foreach (var item in tables)
            {
                var nameNod = item.SelectSingleNode(".//div[@class='decr']//strong[@class='item-name']");
                name.Add(nameNod.InnerText);

                var articleNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//b");
                string articleToTrim = articleNod.InnerText;
                articleToTrim = articleToTrim.Replace("Артикул: ","");
                articleToTrim = articleToTrim.Replace("все","");
                article.Add(articleToTrim);

                var orderCodeNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//small");
                string orderCodeToTrim = orderCodeNod.InnerText;
                orderCodeToTrim = orderCodeToTrim.Replace("Код для заказа: ","");
                orderCode.Add(orderCodeToTrim);

                var vendorNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//span[@class='text']");
                string vendorToTrim = vendorNod.InnerText;
                vendorToTrim = vendorToTrim.Replace("                    Производитель: ","");
                vendor.Add(vendorToTrim);
                

                var priceNod = item.SelectSingleNode(".//div[@class='right-block']//div[@class='price']//b[@class='price-internet']");
                price.Add(priceNod.InnerText);
            }
        }
    }
}
