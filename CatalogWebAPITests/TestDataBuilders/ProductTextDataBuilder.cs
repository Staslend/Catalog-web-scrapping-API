using DatabaseLayer.Models;
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
                product_data_id = 0,
                product_property_name = propertyName,
                property_value = propertyValue
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
