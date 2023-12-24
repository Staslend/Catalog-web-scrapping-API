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

            rawData = await webScrapper.GetRawWebScrapperData("//div[contains(@class,'catalog-item__title')]/a", "https://www.atbmarket.com/catalog/287-ovochi-ta-frukti", "");

            //Assert
            Assert.NotEqual(0, rawData.Count());
        }
    }
}
