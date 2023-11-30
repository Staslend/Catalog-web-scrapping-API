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
                    new ActionDataModel { action_data = "fragPrice" },
                    new ActionDataModel { action_data = "0" },
                    new ActionDataModel { action_data = "3" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { action_data = "productName" },
                    new ActionDataModel { action_data = "1" },
                    new ActionDataModel { action_data = "4" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.ConvertToNumeric, [
                    new ActionDataModel { action_data = "fullPrice" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Merge, [
                    new ActionDataModel { action_data = "fullPrice" },
                    new ActionDataModel { action_data = "intPrice" },
                    new ActionDataModel { action_data = "fragPrice" }]).Build(),
            ];


            //Act
            productNumericData = ProcessActions(ref productTextData, actions);

            //Assert
            Assert.Equal(15.50, productNumericData[0].property_value);
            Assert.Equal("Tomato", productTextData.Single(x => x.product_property_name == "productName").property_value);
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
                    new ActionDataModel { action_data = "fragPrice" },
                    new ActionDataModel { action_data = "0" },
                    new ActionDataModel { action_data = "3" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { action_data = "productName" },
                    new ActionDataModel { action_data = "1" },
                    new ActionDataModel { action_data = "4" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.ConvertToNumeric, [
                    new ActionDataModel { action_data = "fullPrice" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Merge, [
                    new ActionDataModel { action_data = "fullPrice" },
                    new ActionDataModel { action_data = "intPrice" },
                    new ActionDataModel { action_data = "fragPrice" }]).Build(),
            ];

            List<ProductModel> productList = [new ProductModel
            {
                product_numeric_data = productNumericData,
                product_text_data = productTextData,

            }];

            //Act
            List<ProductModel> newProductList = ProcessProductData(productList, actions);

            //Assert
            Assert.Equal(15.50, newProductList[0].product_numeric_data[0].property_value);
            Assert.Equal("Tomato", newProductList[0].product_text_data.Single(x => x.product_property_name == "productName").property_value);
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
                    new ActionDataModel { action_data = "fragPrice" },
                    new ActionDataModel { action_data = "0" },
                    new ActionDataModel { action_data = "3" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Cut, [
                    new ActionDataModel { action_data = "productName" },
                    new ActionDataModel { action_data = "1" },
                    new ActionDataModel { action_data = "4" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.ConvertToNumeric, [
                    new ActionDataModel { action_data = "fullPrice" }]).Build(),
                new ActionModelBuilder().WithAction(ActionName.Merge, [
                    new ActionDataModel { action_data = "fullPrice" },
                    new ActionDataModel { action_data = "intPrice" },
                    new ActionDataModel { action_data = "fragPrice" }]).Build(),
            ];

            List<ProductModel> productList = [new ProductModel
            {
                product_numeric_data = productNumericData,
                product_text_data = productTextData,

            }];

            //Act
            List<ProductModel> newProductList = ProcessProductData(productList, actions);

            //Assert
            Assert.Equal(0, newProductList.Count());
        }
    }
}
