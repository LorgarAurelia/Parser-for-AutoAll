using System;
using System.Collections.Generic;


namespace Parser_for_AutoAll.Core.Parser
{
    class HtmlParser : WebClient
    {
        private readonly string errorOfEmptyTable = "Пришла пустая таблица";
        private readonly string errorOfEmptyHtml = "Пришёл пустой HTML";

        public List<string> name = new();
        public List<string> article = new();
        public List<string> orderCode = new();
        public List<string> vendor = new();
        public List<string> price = new();
        public List<string> pictureLinks = new();
        public void ParseHtml()
        {
            var html = ConnectionToSite();

            HtmlAgilityPack.HtmlDocument document = new();
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
                articleToTrim = articleToTrim.Replace("Артикул: ", "");
                articleToTrim = articleToTrim.Replace("все", "");
                article.Add(articleToTrim);

                var orderCodeNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//small");
                string orderCodeToTrim = orderCodeNod.InnerText;
                orderCodeToTrim = orderCodeToTrim.Replace("Код для заказа: ", "");
                orderCode.Add(orderCodeToTrim);

                var vendorNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//span[@class='text']");
                string vendorToTrim = vendorNod.InnerText;
                vendorToTrim = vendorToTrim.Replace("                    Производитель: ", "");
                vendor.Add(vendorToTrim);


                var priceNod = item.SelectSingleNode(".//div[@class='right-block']//div[@class='price']//b[@class='price-internet']");
                price.Add(priceNod.InnerText);

                pictureLinks.Add(item.SelectSingleNode(".//div[@class='image']//a//img").Attributes["data-src"].Value);
            }
        }
    }
}
