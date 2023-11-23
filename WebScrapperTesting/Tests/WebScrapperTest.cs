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
        public void GetRawWebScrapperData_TestURLAndTestxPath_AmountOfElementsWithSpecificClass()
        {
            //Arrange
            WebScrapper webScrapper = new WebScrapper();

            List<string> rawData = new();
            //Act

            rawData = webScrapper.GetRawWebScrapperData("//h3[@class='fs-5']", "https://phptravels.com/demo/","");

            //Assert
            Assert.Equal(6, rawData.Count());
        }
    }
}
