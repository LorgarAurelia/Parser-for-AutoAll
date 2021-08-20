using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Parser_for_AutoAll.Core.Parser
{
    class DataSystemiser : SystemisedData
    {
        private HtmlParser parser = new HtmlParser();
        public SystemisedData data = new SystemisedData();

        public void Sytemiser() 
        {
            parser.ParseHtml();

            data.name = parser.name;
            data.aricle = parser.article;
            data.orderCode = parser.orderCode;
            data.vendor = parser.vendor;
            data.price = parser.price;
            data.pictureLink = parser.pictureLinks;
        }
    }
}
