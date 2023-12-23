using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperLayer.WebScrapperDataProvider
{
    public interface IWebScrapperDataProvider
    {
        public Task<List<ProductModel>> GetProductsData(List<XPathModel> xPaths, List<ActionModel> actions, string url);

    }
}
