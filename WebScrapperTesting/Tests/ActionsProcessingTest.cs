using WebScrapperLayer.WebScrapperActions;
using WebScrapperTesting.TestDataBuilders;

namespace WebScrapperTesting.Tests
{
    public class ActionsProcessingTest : WebScrapperActions
    {
        [Fact]
        public void ProcessActions_RawWebScrappedData_PriceAndDescription()
        {
            //Arrange
            List<ProductNumericDataModel> productNumericData = new List<ProductNumericDataModel>();

            List<ProductTextDataModel> productTextData = new ProductTextDataBuilder().
                WithTextData("intPrice", "15.").WithTextData("fragPrice", "50grn").WithTextData("productName", "@Tomato____").Build();

            List<ActionModel> actions = [
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { actionData = "fragPrice" },
                    new ActionDataModel { actionData = "0" },
                    new ActionDataModel { actionData = "3" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { actionData = "productName" },
                    new ActionDataModel { actionData = "1" },
                    new ActionDataModel { actionData = "4" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.ConvertToNumeric, [
                    new ActionDataModel { actionData = "fullPrice" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Merge, [
                    new ActionDataModel { actionData = "fullPrice" },
                    new ActionDataModel { actionData = "intPrice" },
                    new ActionDataModel { actionData = "fragPrice" }]).Build(),
            ];


            //Act
            productNumericData = ProcessActions(ref productTextData, actions);

            //Assert
            Assert.Equal(15.50, productNumericData[0].propertyValue);
            Assert.Equal("Tomato", productTextData.Single(x => x.productPropertyName == "productName").propertyValue);
        }

        [Fact]
        public void ProcessProductData_ProductWithRawData_ProductWithProcessedData()
        {
            //Arrange

            List<ProductNumericDataModel> productNumericData = new List<ProductNumericDataModel>();

            List<ProductTextDataModel> productTextData = new ProductTextDataBuilder().
                WithTextData("intPrice", "15.").WithTextData("fragPrice", "50grn").WithTextData("productName", "@Tomato____").Build();

            List<ActionModel> actions = [
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { actionData = "fragPrice" },
                    new ActionDataModel { actionData = "0" },
                    new ActionDataModel { actionData = "3" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { actionData = "productName" },
                    new ActionDataModel { actionData = "1" },
                    new ActionDataModel { actionData = "4" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.ConvertToNumeric, [
                    new ActionDataModel { actionData = "fullPrice" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Merge, [
                    new ActionDataModel { actionData = "fullPrice" },
                    new ActionDataModel { actionData = "intPrice" },
                    new ActionDataModel { actionData = "fragPrice" }]).Build(),
            ];

            List<ProductModel> productList = [new ProductModel
            {
                productNumericData = productNumericData,
                productTextData = productTextData,

            }];

            //Act
            List<ProductModel> newProductList = ProcessProductData(productList, actions);

            //Assert
            Assert.Equal(15.50, newProductList[0].productNumericData[0].propertyValue);
            Assert.Equal("Tomato", newProductList[0].productTextData.Single(x => x.productPropertyName == "productName").propertyValue);
        }
        [Fact]
        public void ProcessProductData_ProductWithWrongRawData_EmptyProductListReturned()
        {
            //Arrange

            List<ProductNumericDataModel> productNumericData = new List<ProductNumericDataModel>();

            List<ProductTextDataModel> productTextData = new ProductTextDataBuilder().
                WithTextData("intPrice", "15.").WithTextData("lols", "50grn").WithTextData("productName", "@Tomato____").Build();

            List<ActionModel> actions = [
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { actionData = "fragPrice" },
                    new ActionDataModel { actionData = "0" },
                    new ActionDataModel { actionData = "3" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { actionData = "productName" },
                    new ActionDataModel { actionData = "1" },
                    new ActionDataModel { actionData = "4" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.ConvertToNumeric, [
                    new ActionDataModel { actionData = "fullPrice" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Merge, [
                    new ActionDataModel { actionData = "fullPrice" },
                    new ActionDataModel { actionData = "intPrice" },
                    new ActionDataModel { actionData = "fragPrice" }]).Build(),
            ];

            List<ProductModel> productList = [new ProductModel
            {
                productNumericData = productNumericData,
                productTextData = productTextData,

            }];

            //Act
            List<ProductModel> newProductList = ProcessProductData(productList, actions);

            //Assert
            Assert.Equal(0, newProductList.Count());
        }
    }
}
