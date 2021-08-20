using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Parser_for_AutoAll.Core.Parser
{
    class DataSystemiser : SystemisedData
    {
        public readonly HtmlParser parser = new();
        public SystemisedData data = new();

        public void Sytemiser() 
        {
            parser.ParseHtml();

            data.Name = parser.name;
            data.Aricle = parser.article;
            data.OrderCode = parser.orderCode;
            data.Vendor = parser.vendor;
            data.Price = parser.price;
            data.PictureLink = parser.pictureLinks;
        }
    }
}
