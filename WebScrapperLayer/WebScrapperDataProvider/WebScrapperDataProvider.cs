using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebScrapperLayer.WebScrapperDataProvider
{
    public class WebScrapperDataProvider : IWebScrapperDataProvider
    {
        WebScrapper.WebScrapper _webScrapper;
        WebScrapperActions.WebScrapperActions _webScrapperActions;

        public WebScrapperDataProvider()
        {
            _webScrapper = new WebScrapper.WebScrapper();
            _webScrapperActions = new WebScrapperActions.WebScrapperActions();
        }

        //Я переживаю что весь этот процесс будет занимать слишком много времени. скорее всего я оптимизировал его не самым лучшим образом
        //TODO: Optimise web scrapping process
        public List<ProductModel> GetProductsData(List<XPathModel> xPaths, List<ActionModel> actions,  string url)
        {
            List<ProductModel> finalProductList = new List<ProductModel>();

            foreach (XPathModel xPath in xPaths)
            {
                //Web scrapping data from url by xpath
                List<string> bufferDataList = _webScrapper.GetRawWebScrapperData(xPath.xPath, url, xPath.atribute);

                //Create products with data
                if(finalProductList.Count == 0 )
                {
                    foreach(string rawData in  bufferDataList)
                    {
                        finalProductList.Add(new ProductModel
                        {
                            productTextData = new List<ProductTextDataModel>
                            {
                                new ProductTextDataModel
                                {
                                    productPropertyName = xPath.propertyName,
                                    propertyValue = rawData
                                }
                            }
                        });
                    }
                }
 
                for(int productNumber = 0; productNumber < finalProductList.Count; productNumber++)
                {
                    finalProductList[productNumber].productTextData.Add(new ProductTextDataModel
                    {
                        productPropertyName = xPath.propertyName,
                        propertyValue = bufferDataList[productNumber]
                    }) ;
                }


            }
        
            return _webScrapperActions.ProcessProductData(finalProductList, actions);
        }
    }
}
