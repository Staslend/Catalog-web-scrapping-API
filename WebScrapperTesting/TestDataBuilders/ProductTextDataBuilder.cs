using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperTesting.TestDataBuilders
{
    public class ProductTextDataBuilder
    {
        List<ProductTextDataModel> productTextData = new();

        public ProductTextDataBuilder WithTextData(string propertyName, string propertyValue)
        {
            productTextData.Add(new ProductTextDataModel
            {
                productDataId = 0,
                productPropertyName = propertyName,
                propertyValue = propertyValue
            });
            return this;
        }
        public void ClearProductDataList()
        {
            productTextData.Clear();
        }

        public List<ProductTextDataModel> Build()
        {
            return productTextData;
        }
    }
}
