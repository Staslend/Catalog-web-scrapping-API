using DatabaseLayer.Models;
using System.Reflection.Metadata;
using WebScrapperLayer.WebScrapperActions;
using WebScrapperTesting.TestDataBuilders;
using WebScrapperTesting.WebScrapperDataFactory;

namespace WebScrapperTesting.Tests
{
    public class ActionsTest : WebScrapperActions
    {

        [Theory]
        [InlineData(ActionName.Cut, ActionType.Editing)]
        [InlineData(ActionName.Merge, ActionType.Merging)]
        [InlineData(ActionName.ConvertToNumeric, ActionType.Converting)]
        public void GetActionType_ActionName_ActionType(ActionName actionName, ActionType expectedType)
        {
            //Arrange

            //Act
            ActionType returnedType = GetActionType(actionName);

            //Assert
            Assert.Equal(expectedType, returnedType);

        }

        [Fact]
        public void CutAction_PriceWithExtraWord_WordIsRemoved()
        {
            //Arrange
            ProductModel model = new ProductModelBuilder().WithProductTextData(
                new ProductTextDataBuilder().WithTextData("price","192.23grn").Build()
                ).Build();

            ActionModel action = new ActionModelBuilder().WithAction(ActionName.Cut, [
                new ActionDataModel { action_data = "price" },
                new ActionDataModel { action_data ="0"},
                new ActionDataModel { action_data = "3"},
            ]).Build();

            List<ProductTextDataModel> productTextData;
            //Act

            productTextData = model.product_text_data;
            CutAction(ref productTextData, action);
            model.product_text_data = productTextData;

            //Assert
            Assert.Equal("192.23", model.product_text_data[0].property_value);
            Assert.Equal("price", model.product_text_data[0].product_property_name);

        }

        [Fact]
        public void MergetAction_IntegerPriceAndFractionPrice_FullPrice()
        {
            //Arrange
            ProductModel model = new ProductModelBuilder().WithProductTextData(
                new ProductTextDataBuilder().WithTextData("intPrice", "192.").WithTextData("fracPrice", "23").Build()
                ).Build();

            ActionModel action = new ActionModelBuilder().WithAction(ActionName.Merge, [
                new ActionDataModel { action_data = "fullPrice" },
                new ActionDataModel { action_data = "intPrice" },
                new ActionDataModel { action_data = "fracPrice" },
            ]).Build();

            List<ProductTextDataModel> productTextData;

            //Act
            productTextData = model.product_text_data;

            MergeAction(ref productTextData, action);

            model.product_text_data = productTextData;
            //Assert
            Assert.Equal("192.23", model.product_text_data[0].property_value);
            Assert.Equal("fullPrice", model.product_text_data[0].product_property_name);

        }

        [Fact]
        public void ConvertToNumeric_NumericDataInString_StringConvertedToDouble()
        {
            //Arrange
            ProductModel model = new ProductModelBuilder().WithProductTextData(
                new ProductTextDataBuilder().WithTextData("price", "192.23").Build()
                ).Build();


            ActionModel action = new ActionModelBuilder().WithAction(ActionName.ConvertToNumeric,
                [new ActionDataModel { action_data = "price"}]).Build();

            List<ProductTextDataModel> productTextData;
            List<ProductNumericDataModel> productNumericData;
            //Act
            productTextData = model.product_text_data;
            productNumericData = model.product_numeric_data;
            ConvertToNumericAction(ref productTextData, ref productNumericData, action);

            model.product_text_data = productTextData;
            model.product_numeric_data = productNumericData;

            //Assert
            Assert.Equal(192.23, model.product_numeric_data[0].property_value);
        }
    }
}