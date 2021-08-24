using System;
using System.Collections.Generic;

namespace Parser_for_AutoAll.Core.Parser
{
    class HtmlParser : ConnectionToSite
    {
        private readonly ErrorMessages errors = new();

        public SystemisedData savedData = new();

        public void ParseHtml()
        {
            var html = Connect();

            HtmlAgilityPack.HtmlDocument document = new();
            if (!string.IsNullOrEmpty(html))
                document.LoadHtml(html);
            else
            {
                Console.WriteLine(errors.errorOfEmptyHtml);
                Environment.Exit(0);
            }

            var tables = document.DocumentNode.SelectNodes(".//div[@class='list-compact']//div[@class='item item-elem']");
            if (tables == null)
            {
                Console.WriteLine(errors.errorOfEmptyTable);
                Environment.Exit(0);
            }


            foreach (var item in tables)
            {
                var nameNod = item.SelectSingleNode(".//div[@class='decr']//strong[@class='item-name']");
                if (nameNod != null)
                    savedData.Name.Add(nameNod.InnerText);
                else if(nameNod == null) 
                {
                    Console.WriteLine(errors.errorOfEmptyNode);
                    savedData.Name.Add(errors.badValue);
                }

                var articleNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//b");
                if (articleNod != null)
                {
                    string articleToTrim = articleNod.InnerText;
                    articleToTrim = articleToTrim.Replace("Артикул: ", "");
                    articleToTrim = articleToTrim.Replace("все", "");
                    savedData.Article.Add(articleToTrim);
                }
                else if (articleNod == null) 
                {
                    Console.WriteLine(errors.errorOfEmptyNode);
                    savedData.Name.Add(errors.badValue);
                }
                
                var orderCodeNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//small");
                if (orderCodeNod != null)
                {
                    string orderCodeToTrim = orderCodeNod.InnerText;
                    orderCodeToTrim = orderCodeToTrim.Replace("Код для заказа: ", "");
                    savedData.OrderCode.Add(orderCodeToTrim);
                } else if (orderCodeNod == null) 
                {
                    Console.WriteLine(errors.errorOfEmptyNode);
                    savedData.Name.Add(errors.badValue);
                }
                

                var vendorNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//span[@class='text']");
                if (vendorNod != null)
                {
                    string vendorToTrim = vendorNod.InnerText;
                    vendorToTrim = vendorToTrim.Replace("                    Производитель: ", "");
                    savedData.Vendor.Add(vendorToTrim);
                } else if (vendorNod == null) 
                {
                    Console.WriteLine(errors.errorOfEmptyNode);
                    savedData.Name.Add(errors.badValue);
                }
                
                var priceNod = item.SelectSingleNode(".//div[@class='right-block']//div[@class='price']//b[@class='price-internet']");
                if (priceNod != null)
                    savedData.Price.Add(priceNod.InnerText);
                else if (priceNod != null) 
                {
                    Console.WriteLine(errors.errorOfEmptyNode);
                    savedData.Name.Add(errors.badValue);
                } 

                var pictureNod = item.SelectSingleNode(".//div[@class='image']//a//img").Attributes["data-src"].Value;
                if (pictureNod != null)
                    savedData.PictureLink.Add(pictureNod);
                else if (pictureNod == null) 
                {
                    Console.WriteLine(errors.errorOfEmptyNode);
                    savedData.Name.Add(errors.badValue);
                }
            }
        }
    }
}
