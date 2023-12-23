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

        string _previousUrl = String.Empty;

        HtmlNodeCollection _previousNamenodes = null;
        HtmlNodeCollection _namenodes = null;

        public WebScrapper() {
            _htmlWeb = new HtmlWeb();
            _htmlDocument = new HtmlDocument();
        }

        private bool NodeCollectionsAreIdentical(HtmlNodeCollection nc1, HtmlNodeCollection nc2)
        {
            if (nc1.Count == nc2.Count)
            {
                for (int i = 0; i < nc1.Count; i++)
                {
                    if (nc1[i].InnerText != nc2[i].InnerText) return false;
                }
                return true;
            }
            return false;

        }

        public async Task<List<string>> GetRawWebScrapperData(string xPath, string url, string atribute)
        {
            if(_previousUrl != url)  _htmlDocument = await _htmlWeb.LoadFromWebAsync(url);

            _previousNamenodes = _namenodes;
            _namenodes = _htmlDocument.DocumentNode.SelectNodes(xPath);

            //Check if the same data was loaded like in previous request
            if(_previousNamenodes is not null && _namenodes is not null)
            {
                if (NodeCollectionsAreIdentical(_previousNamenodes, _namenodes)) return null;
            }

            if (atribute == String.Empty)
            {
                return _namenodes.Select(n => n.InnerText).ToList();

            }
            return _namenodes.Select(n => n.Attributes[atribute].Value).ToList();
        }

    }
}
