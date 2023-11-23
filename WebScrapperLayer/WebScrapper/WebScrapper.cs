using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScrapperLayer.WebScrapper
{
    public class WebScrapper : IWebScrapper
    {
        HtmlWeb _htmlWeb;
        HtmlDocument _htmlDocument;

        string previousUrl = String.Empty;

        public WebScrapper() {
            _htmlWeb = new HtmlWeb();
            _htmlDocument = new HtmlDocument();
        }

        public List<string> GetRawWebScrapperData(string xPath, string url, string atribute)
        {
            if(previousUrl != url)  _htmlDocument = _htmlWeb.Load(url);

            HtmlNodeCollection namenodes = _htmlDocument.DocumentNode.SelectNodes(xPath);

            if(atribute == String.Empty)
            {
                return namenodes.Select(n => n.InnerText).ToList();

            }
            return namenodes.Select(n => n.Attributes[atribute].Value).ToList();
        }

    }
}
