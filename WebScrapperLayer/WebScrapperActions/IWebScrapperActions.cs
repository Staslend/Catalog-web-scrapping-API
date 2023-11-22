using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperLayer.WebScrapperActions
{
    internal interface IWebScrapperActions
    {
        public List<ProductModel> ProcessProductData(List<ProductModel> rawProducts, List<ActionModel> actions);
    }
}
