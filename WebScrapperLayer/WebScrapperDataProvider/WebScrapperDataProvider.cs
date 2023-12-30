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

        List<ProductModel> _previousProductList;

        public WebScrapperDataProvider()
        {
            _webScrapper = new WebScrapper.WebScrapper();
            _webScrapperActions = new WebScrapperActions.WebScrapperActions();
        }

        //Я переживаю что весь этот процесс будет занимать слишком много времени. скорее всего я оптимизировал его не самым лучшим образом
        //TODO: Optimise web scrapping process
        public async Task<List<ProductModel>> GetProductsData(List<XPathModel> xPaths, List<ActionModel> actions,  string url)
        {
            List<ProductModel> finalProductList = new List<ProductModel>();

            foreach (XPathModel xPath in xPaths)
            {
                //Web scrapping data from url by xpath
                List<string> bufferDataList = await _webScrapper.GetRawWebScrapperData(xPath.xpath, url, xPath.atribute);

                if(bufferDataList is null)
                {
                    return null;
                }

                //Create products with data
                if(finalProductList.Count == 0 )
                {
                    foreach(string rawData in  bufferDataList)
                    {
                        finalProductList.Add(new ProductModel
                        {
                            product_text_data = new List<ProductTextDataModel>
                            {
                                new ProductTextDataModel
                                {
                                    product_property_name = xPath.property_name,
                                    property_value = rawData
                                }
                            }
                        });
                    }
                }
 
                for(int productNumber = 0; productNumber < finalProductList.Count; productNumber++)
                {
                    finalProductList[productNumber].product_text_data.Add(new ProductTextDataModel
                    {
                        product_property_name = xPath.property_name,
                        property_value = bufferDataList[productNumber]
                    }) ;
                }


            }

            return _webScrapperActions.ProcessProductData(finalProductList, actions);
        }
    }
}
