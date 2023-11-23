using HtmlAgilityPack;
using DatabaseLayer.Models;
using PriceAPI.Services.ShopNameService;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace PriceAPI.Services.WebScrappingService
{
    public class SeleniumWebScrapper : IWebScrapper
    {

        ChromeDriver driver;
        IShopNameService _shopNameService;
        public SeleniumWebScrapper(IShopNameService shopNameService)
        {
            _shopNameService = shopNameService;
            ChromeOptions opt = new ChromeOptions();
            opt.AddArgument("headless");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0,0,0,10,0,0);
        }


        public async Task<List<ProductModel>> GetProducts(string link)
        {
            List<ProductModel> returnList = new List<ProductModel>();

            string prevFirstNode = null;
            string shopName = _shopNameService.GetShopName(link);

            bool pagesNotEnded = true;
            for (int x = 1; pagesNotEnded; x++)
            {
                driver.Navigate().GoToUrl(link + x.ToString()); 

                switch (shopName)
                {
                    //ATB ------------------------------------------------------------------------------------------------------------------
                    case "АТБ":
                        {
                            var namenodes = driver.FindElements(By.XPath("//div[contains(@class, 'catalog-item__title')]/a"));

                            if (prevFirstNode is not null && namenodes[0].Text == prevFirstNode)
                            {
                                return returnList;
                            }


                            var pricenodes = driver.FindElements(By.XPath("//article[contains(@class, 'catalog-item')]/div[contains(@class, 'catalog-item__bottom')]/div[contains(@class, 'catalog-item__product-price product-price product-price--weight ')]/data[contains(@class, 'product-price__top')]"));

                            for (int y = 0; y < namenodes.Count; y++)
                            {
                                returnList.Add(new ProductModel
                                {
                                    //Name = namenodes[y].Text,
                                    //Price = Double.Parse(pricenodes[y].GetAttribute("value")),
                                    //Shop = shopName
                                });
                            }
                            prevFirstNode = namenodes[0].Text;
                            break;
                        }
                    //EKOmarket ------------------------------------------------------------------------------------------------------------------
                    case "ЕКОмаркет":
                        {
                            var namenodes = driver.FindElements(By.XPath("//span[contains(@data-testid, 'product_tile_title')]"));

                            if (namenodes.Count == 0 || (prevFirstNode is not null && namenodes[0].Text == prevFirstNode))
                            {
                                return returnList;
                            }


                            var pricenodes = driver.FindElements(By.XPath("//span[contains(@class, 'Price__value_caption')]"));

                            for (int y = 0; y < namenodes.Count; y++)
                            {
                                returnList.Add(new ProductModel
                                {
                                    //Name = namenodes[y].Text,
                                    //Price = Double.Parse(pricenodes[y].Text),
                                    //Shop = shopName
                                });
                            }
                            prevFirstNode = namenodes[0].Text;
                            break;
                        }
                    case "Сільпо":
                        {
                            var namenodes = driver.FindElements(By.XPath("//a[contains(@class, 'product-card__title')]"));

                            if (namenodes.Count == 0 || (prevFirstNode is not null && namenodes[0].Text == prevFirstNode))
                            {
                                return returnList;
                            }


                            var pricenodes = driver.FindElements(By.XPath("//div[contains(@class, 'product-card__body')]/div[contains(@class, 'ft-whitespace-nowrap ')]"));


                            for (int y = 0; y < namenodes.Count; y++)
                            {
                                returnList.Add(new ProductModel
                                {
                                    //Name = namenodes[y].Text,
                                    //Price = Double.Parse(pricenodes[y].Text.Substring(0, pricenodes[y].Text.Length - 3)),
                                    //Shop = shopName
                                });
                            }
                            prevFirstNode = namenodes[0].Text;
                            break;
                        }
                }

            }
            return returnList;
        }
    }
}
