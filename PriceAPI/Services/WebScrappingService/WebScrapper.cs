using HtmlAgilityPack;
using PriceAPI.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;

namespace PriceAPI.Services.WebScrappingService
{
    public class WebScrapper : IWebScrapper
    {
        public async Task<List<ProductModel>> GetProducts(PageModel link)
        {
            HtmlWeb web = new HtmlWeb();
            List < ProductModel > returnList = new List<ProductModel> ();

                for(int x = 1; x < link.pages; x++)
                {
                    var htmlDoc = web.Load(link.link + x.ToString());
                    HtmlNodeCollection namenodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'catalog-item__title')]/a");
                    HtmlNodeCollection pricenodes = htmlDoc.DocumentNode.SelectNodes("//article[contains(@class, 'catalog-item')]/div[contains(@class, 'catalog-item__bottom')]/div[contains(@class, 'catalog-item__product-price product-price product-price--weight ')]/data[contains(@class, 'product-price__top')]");

                for(int y = 0; y < namenodes.Count; y++)
                {
                    returnList.Add(new ProductModel {
                        Name = namenodes[y].InnerText,
                        Price = Double.Parse(pricenodes[y].Attributes["value"].Value),
                        Shop = link.shop
                    }) ;
                }
                }
            return returnList;
        }
    }
}
