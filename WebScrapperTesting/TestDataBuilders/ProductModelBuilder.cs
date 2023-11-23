using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapperTesting.TestDataBuilders;

namespace WebScrapperTesting.WebScrapperDataFactory
{
    public class ProductModelBuilder
    {
        int productId = 0;
        List<ProductTextDataModel> productTextData = new ProductTextDataBuilder().Build();
        List<ProductNumericDataModel> productNumericData = new ProductNumericDataBuilder().Build();
        public ProductModelBuilder() 
        {
        } 
        public ProductModelBuilder WithId(int id)
        {
            this.productId = id;
            return this;
        }

        public ProductModelBuilder WithProductTextData(List<ProductTextDataModel> productTextData)
        {
            this.productTextData = productTextData;
            return this;
        }
        public ProductModelBuilder WithProductNumericData(List<ProductNumericDataModel> productNumericData)
        {
            this.productNumericData = productNumericData;
            return this;
        }

        public void ClearProductData()
        {
            this.productTextData.Clear();
            this.productNumericData.Clear();
        }

        public ProductModel Build()
        {
            return new ProductModel
            {
                productNumericData = productNumericData,
                productTextData = productTextData
            };
        }

    }
}
