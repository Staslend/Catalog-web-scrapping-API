using DataAccessLayer.DataAccess.ProductsDbAccess;
using DatabaseLayer.DataContexts;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerTesting.ProductsAccessTests
{
    public class ProductsAccessTest
    {
        IProductsDbAccess productsDbAccess;

        public ProductsAccessTest() {
            Mock<ProductAPIDbContext> productAPIDbContext = new Mock<ProductAPIDbContext>();

            var productsData = new List<ProductModel>
            {
                new ProductModel
                {
                    product_id = 1,
                    product_text_data = new List<ProductTextDataModel>
                    {
                        new ProductTextDataModel
                        {
                            product_id = 1,
                            product_data_id = 1,
                            product_property_name = "productName",
                            property_value = "c"
                        },
                        new ProductTextDataModel
                        {
                            product_id = 1,
                            product_data_id = 2,
                            product_property_name = "data2",
                            property_value = "value 0"
                        },
                        new ProductTextDataModel
                        {
                            product_id = 1,
                            product_data_id = 3,
                            product_property_name = "data3",
                            property_value = "value 3"
                        },
                    }
                },
                new ProductModel
                {
                    product_id = 2,
                    product_text_data = new List<ProductTextDataModel>
                    {
                        new ProductTextDataModel
                        {
                            product_id = 2,
                            product_data_id = 4,
                            product_property_name = "productName",
                            property_value = "b"
                        },
                        new ProductTextDataModel
                        {
                            product_id = 2,
                            product_data_id = 5,
                            product_property_name = "data2",
                            property_value = "value 5"
                        }
                    }
                },
                new ProductModel
                {
                    product_id = 3,
                    product_text_data = new List<ProductTextDataModel>
                    {
                        new ProductTextDataModel
                        {
                            product_id = 3,
                            product_data_id = 6,
                            product_property_name = "productName",
                            property_value = "a"
                        },
                        new ProductTextDataModel
                        {
                            product_id = 3,
                            product_data_id = 7,
                            product_property_name = "data2",
                            property_value = "value 0"
                        }
                    }
                }

            };

            var productTextData = new List<ProductTextDataModel>();
            productTextData.AddRange(productsData[0].product_text_data);
            productTextData.AddRange(productsData[1].product_text_data);
            productTextData.AddRange(productsData[2].product_text_data);

            var productTextDataMock = productTextData.AsQueryable().BuildMockDbSet();
            var productsMock = productsData.AsQueryable().BuildMockDbSet();

            productAPIDbContext.SetupGet(x => x.products).Returns(productsMock.Object);
            productAPIDbContext.SetupGet(x => x.productsTextData).Returns(productTextDataMock.Object);

            int a = productAPIDbContext.Object.products.ElementAt(0).product_text_data.Count();

            productsDbAccess = new ProductsDbAccess(productAPIDbContext.Object);
        }


        [Fact]
        public async void GetProduct_IdOfTheProduct_SingleProduct2()
        {
            //Arrange

            //Act

             ProductModel unsortedProduct = await productsDbAccess.GetProduct(1);

            //Assert
            Assert.Equal(1, unsortedProduct.product_id);
            Assert.Equal("c", unsortedProduct.product_text_data[0].property_value);

        }


        [Fact]
        public async void GetProducts_ProductFilteredByProductName_SingleProduct()
        {


            ProductQueryData productQueryData = new ProductQueryData
            {
                textDataFilter = new Dictionary<string, string>(),
                numericDataFilter = new Dictionary<string, double>()
            };
            productQueryData.textDataFilter.Add("productName", "a");

            //Act

            List<ProductModel> product = await productsDbAccess.GetProducts(productQueryData);

            //Assert
            Assert.Single(product);
            Assert.Equal("a", product[0].product_text_data[0].property_value);
               
        }
        [Fact]
        public async void GetProducts_GetProductFilteredByProductDataAndOrderedByName_ListOfProducts()
        {
            //Arrange
            ProductQueryData productQueryData = new ProductQueryData
            {
                textDataFilter = new Dictionary<string, string>(),
                numericDataFilter = new Dictionary<string, double>()
            };
            productQueryData.textDataFilter.Add("data2", "value 0");
            productQueryData.order = "productName";

            //Act

            List<ProductModel> filteredOrderdProducts = await productsDbAccess.GetProducts(productQueryData);

            //Assert
            Assert.Equal(3, filteredOrderdProducts[0].product_id);
            Assert.Equal(1, filteredOrderdProducts[1].product_id);
            Assert.Equal(2, filteredOrderdProducts.Count);


        }

        [Fact]
        public async void GetProducts_GetProductsWithEmptyDataObject_RawListOfProducts()
        {
            //Arrange
 
            ProductQueryData productQueryData = new ProductQueryData();

            //Act

            List<ProductModel> filteredOrderdProducts = await productsDbAccess.GetProducts(productQueryData);

            //Assert
            Assert.Equal(3, filteredOrderdProducts.Count);
        }
    }
}
