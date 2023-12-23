using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperLayer.WebScrapper
{
    internal interface IWebScrapper
    {
        public Task<List<string>> GetRawWebScrapperData(string xPath, string url, string atribute = "");

    }
}
