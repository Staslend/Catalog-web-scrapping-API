using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperTesting.TestDataBuilders
{
    public class ProductNumericDataBuilder
    {
        List<ProductNumericDataModel> productsNumericData = new();

        public ProductNumericDataBuilder() { }

        public ProductNumericDataBuilder WithNumericData(string propertyName, double propertyValue)
        {
            productsNumericData.Add(new ProductNumericDataModel
            {
                productDataId = 0,
                productPropertyName = propertyName,
                propertyValue = propertyValue
            });
            return this;
        }

        public void ClearProductDataList()
        {
            productsNumericData.Clear();
        }

        public List<ProductNumericDataModel> Build()
        {
            return productsNumericData;
        }
    }
}
