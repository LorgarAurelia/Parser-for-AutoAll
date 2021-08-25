using System;
using System.Collections.Generic;
using System.IO;

namespace Parser_for_AutoAll.Core.Parser
{
    class HtmlParser : Requester
    {
        public static List<SystemisedData> ParseHtml()
        {
            string path = @"c:\picture";

            List<SystemisedData> parsedData = new();

            string html = PageLoader(NetworkParamaters.url);

            HtmlAgilityPack.HtmlDocument document = new();

            if (!string.IsNullOrEmpty(html))
                document.LoadHtml(html);
            else
                throw new Exception(ErrorMessages.errorOfEmptyHtml);


            var tables = document.DocumentNode.SelectNodes(".//div[@class='list-compact']//div[@class='item item-elem']");
            if (tables == null)
                throw new Exception(ErrorMessages.errorOfEmptyTable);


            foreach (var item in tables)
            {
                SystemisedData data = new();
                data.Name = item.SelectSingleNode(".//div[@class='decr']//strong[@class='item-name']")?.InnerText;

                var articleNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//b");
                data.Article = articleNod?.InnerText.Replace("Артикул: ", "").Replace("все","");
                
                var orderCodeNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//small");
                data.OrderCode = orderCodeNod?.InnerText.Replace("Код для заказа: ", "");
                
                var vendorNod = item.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//span[@class='text']");
                data.Vendor = vendorNod?.InnerText.Replace("                    Производитель: ", "");
                
                data.Price = item.SelectSingleNode(".//div[@class='right-block']//div[@class='price']//b[@class='price-internet']")?.InnerText; 

                data.PictureLink = item.SelectSingleNode(".//div[@class='image']//a//img").Attributes["data-src"].Value;

                Directory.CreateDirectory(path);
                PictureLoader(data.OrderCode, data.PictureLink, path);

                parsedData.Add(data);
            }

            return parsedData;
        }
    }
}
