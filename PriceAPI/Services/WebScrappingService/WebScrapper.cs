using HtmlAgilityPack;
using DatabaseLayer.Models;
using PriceAPI.Services.ShopNameService;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;

namespace PriceAPI.Services.WebScrappingService
{
    public class WebScrapper : IWebScrapper
    {
        IShopNameService _shopNameService;
        public WebScrapper(IShopNameService shopNameService)
        {
            _shopNameService = shopNameService;
        }

        public async Task<List<ProductModel>> GetProducts(string link)
        {
            HtmlWeb web = new HtmlWeb();
            List<ProductModel> returnList = new List<ProductModel>();

            HtmlNode prevFirstNode = null;
            string shopName = _shopNameService.GetShopName(link);

            bool pagesNotEnded = true;
            for (int x = 1; pagesNotEnded; x++)
            {
                var htmlDoc = web.Load(link + x.ToString());


                switch (shopName)
                {
                    //ATB ------------------------------------------------------------------------------------------------------------------
                    case "АТБ":
                        {
                            HtmlNodeCollection namenodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'catalog-item__title')]/a");

                            if (prevFirstNode is not null && namenodes[0].InnerText == prevFirstNode.InnerText)
                            {
                                return returnList;
                            }


                            HtmlNodeCollection pricenodes = htmlDoc.DocumentNode.SelectNodes("//article[contains(@class, 'catalog-item')]/div[contains(@class, 'catalog-item__bottom')]/div[contains(@class, 'catalog-item__product-price product-price product-price--weight ')]/data[contains(@class, 'product-price__top')]");

                            for (int y = 0; y < namenodes.Count; y++)
                            {
                                returnList.Add(new ProductModel
                                {
                                    //Name = namenodes[y].InnerText,
                                    //Price = Double.Parse(pricenodes[y].Attributes["value"].Value),
                                    //Shop = shopName
                                });
                            }
                            prevFirstNode = namenodes[0];
                            break;
                        }
                    //EKOmarket ------------------------------------------------------------------------------------------------------------------
                    case "ЕКОмаркет":
                        {
                            HtmlNodeCollection namenodes = htmlDoc.DocumentNode.SelectNodes("//span[contains(@data-testid, 'product_tile_title')]");

                            if (namenodes is null || (prevFirstNode is not null && namenodes[0].InnerText == prevFirstNode.InnerText))
                            {
                                return returnList;
                            }


                            HtmlNodeCollection pricenodes = htmlDoc.DocumentNode.SelectNodes("//span[contains(@class, 'Price__value_caption')]");

                            for (int y = 0; y < namenodes.Count; y++)
                            {
                                returnList.Add(new ProductModel
                                {
                                    //Name = namenodes[y].InnerText,
                                    //Price = Double.Parse(pricenodes[y].InnerText),
                                    //Shop = shopName
                                });
                            }
                            prevFirstNode = namenodes[0];
                            break;
                        }
                    case "Сільпо":
                        {
                            HtmlNodeCollection namenodes = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'product-card__title')]");

                            if (namenodes is null || (prevFirstNode is not null && namenodes[0].InnerText == prevFirstNode.InnerText))
                            {
                                return returnList;
                            }


                            HtmlNodeCollection pricenodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'product-card__body')]/div[contains(@class, 'ft-whitespace-nowrap ')]");


                            for (int y = 0; y < namenodes.Count; y++)
                            {
                                returnList.Add(new ProductModel
                                {
                                    //Name = namenodes[y].InnerText,
                                    //Price = Double.Parse(pricenodes[y].InnerText.Substring(0, pricenodes[y].InnerText.Length-3)),
                                    //Shop = shopName
                                });
                            }
                            prevFirstNode = namenodes[0];
                            break;
                        }
                }

            }
            return returnList;
        }
    }
}
