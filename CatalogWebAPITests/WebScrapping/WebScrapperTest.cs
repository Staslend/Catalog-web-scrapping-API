using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapperLayer.WebScrapper;

namespace WebScrapperTesting.Tests
{
    public class WebScrapperTest
    {
        [Fact]
        public async void GetRawWebScrapperData_TestURLAndTestxPath_AmountOfElementsWithSpecificClass()
        {
            //Arrange
            WebScrapper webScrapper = new WebScrapper();

            List<string> rawData = new();
            //Act

            ////div[contains(@class,'catalog-item__bottom')]/div[contains(@class, 'catalog-item__product-price')]/div[contains(@class,'product-price__top')]/data
            rawData = await webScrapper.GetRawWebScrapperData("//div[contains(@class,'product-price--weight')]/data[@class='product-price__top']", "https://www.atbmarket.com/catalog/287-ovochi-ta-frukti", "value");

            //Assert
            Assert.Equal(36, rawData.Count());
        }
    }
}
