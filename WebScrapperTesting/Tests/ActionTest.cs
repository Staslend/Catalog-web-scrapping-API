using DatabaseLayer.Models;
using System.Reflection.Metadata;
using WebScrapperLayer.WebScrapperActions;
using WebScrapperTesting.TestDataBuilders;
using WebScrapperTesting.WebScrapperDataFactory;

namespace WebScrapperTesting.Tests
{
    public class ActionTest : WebScrapperActions
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

            ActionModel action = new ActionModelBuilder().WithAction(ActionName.Cut, "price", "0", "3").Build();

            //Act

            CutAction(ref model.productTextData, action);
            //Assert
            Assert.Equal("192.23", model.productTextData[0].propertyValue);
            Assert.Equal("price", model.productTextData[0].propertyValue);

        }

        [Fact]
        public void MergetAction_IntegerPriceAndFractionPrice_FullPrice()
        {
            //Arrange
            ProductModel model = new ProductModelBuilder().WithProductTextData(
                new ProductTextDataBuilder().WithTextData("intPrice", "192.").WithTextData("fracPrice", "23").Build()
                ).Build();

            ActionModel action = new ActionModelBuilder().WithAction(ActionName.Merge, "fullPrice", "intPrice", "fracPrice").Build();
            
            //Act
            MergeAction(ref model.productTextData, action);

            //Assert
            Assert.Equal("192.23", model.productTextData[0].propertyValue);
            Assert.Equal("fullPrice", model.productTextData[0].productPropertyName);

        }

        [Fact]
        public void ConvertToNumeric_NumericDataInString_StringConvertedToDouble()
        {
            //Arrange
            ProductModel model = new ProductModelBuilder().WithProductTextData(
                new ProductTextDataBuilder().WithTextData("price", "192.23").Build()
                ).Build();


            ActionModel action = new ActionModelBuilder().WithAction(ActionName.ConvertToNumeric, "fullPrice", "","").Build();

            //Act
            ConvertAction(ref model.productTextData, ref model.productNumericData, action);

            //Assert
            Assert.Equal(192.23, model.productNumericData[0].propertyValue);
        }
    }
}