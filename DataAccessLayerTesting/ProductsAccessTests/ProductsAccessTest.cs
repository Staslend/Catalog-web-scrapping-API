using DataAccessLayer.DataAccess.ProductsDbAccess;
using DatabaseLayer.DataContexts;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
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
        [Fact]
        public void GetProducts_SecondPageAndNoOrderingData_ListWithOneProduct()
        {
            //Arrange
            var products = new List<ProductModel>
            {
                new ProductModel
                {
                    product_id = 1,
                    product_text_data = new List<ProductTextDataModel>
                    {
                        new ProductTextDataModel
                        {
                            product_data_id = 1,
                            product_property_name = "productName",
                            property_value = "1 apple"
                        },
                        new ProductTextDataModel
                        {
                            product_data_id = 2,
                            product_property_name = "data2",
                            property_value = "value 2"
                        },
                        new ProductTextDataModel
                        {
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
                            product_data_id = 4,
                            product_property_name = "productName",
                            property_value = "2 tomato"
                        },
                        new ProductTextDataModel
                        {
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
                            product_data_id = 6,
                            product_property_name = "productName",
                            property_value = "3 cheese"
                        },
                        new ProductTextDataModel
                        {
                            product_data_id = 7,
                            product_property_name = "data2",
                            property_value = "value 0"
                        }
                    }
                }

            }.AsQueryable();

            var productsMock = new Mock<DbSet<ProductModel>>();

            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.Provider).Returns(products.Provider);
            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.Expression).Returns(products.Expression);
            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.ElementType).Returns(products.ElementType);
            productsMock.As<IQueryable<ProductModel>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var dbContextMock = new Mock<ProductAPIDbContext>();

            dbContextMock.SetupGet(c => c.products).Returns(productsMock.Object);

            IProductsDbAccess productsDbAccess = new ProductsDbAccess(dbContextMock.Object);
            //Act

            ProductModel unsortedProduct = productsDbAccess.GetProduct(1);

            //Assert
            Assert.Equal(1, unsortedProduct.product_id);
            Assert.Equal("1 apple", unsortedProduct.product_text_data[0].property_value);

        }
        [Fact]
        public void GetProducts_ProductFilteredByProductName_SingleProduct()
        {
            var products = new List<ProductModel>
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

            }.AsQueryable();

            var productsMock = new Mock<DbSet<ProductModel>>();

            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.Provider).Returns(products.Provider);
            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.Expression).Returns(products.Expression);
            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.ElementType).Returns(products.ElementType);
            productsMock.As<IQueryable<ProductModel>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            List<ProductTextDataModel> productTextData = new();

            productTextData.AddRange(products.AsEnumerable().ToList()[0].product_text_data);
            productTextData.AddRange(products.AsEnumerable().ToList()[1].product_text_data);
            productTextData.AddRange(products.AsEnumerable().ToList()[2].product_text_data);

            var productTextDataMock = new Mock<DbSet<ProductTextDataModel>>();

            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.Provider).Returns(productTextData.AsQueryable().Provider);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.Expression).Returns(productTextData.AsQueryable().Expression);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.ElementType).Returns(productTextData.AsQueryable().ElementType);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().Setup(m => m.GetEnumerator()).Returns(productTextData.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ProductAPIDbContext>();

            dbContextMock.SetupGet(c => c.products).Returns(productsMock.Object);
            dbContextMock.SetupGet(c => c.productsTextData).Returns(productTextDataMock.Object);

            IProductsDbAccess productsDbAccess = new ProductsDbAccess(dbContextMock.Object);


            ProductQueryData productQueryData = new ProductQueryData
            {
                textDataFilter = new Dictionary<string, string>(),
                numericDataFilter = new Dictionary<string, double>()
            };
            productQueryData.textDataFilter.Add("productName", "a");

            //Act

            List<ProductModel> product = productsDbAccess.GetProducts(productQueryData);

            //Assert
            Assert.Single(product);
            Assert.Equal("a", product[0].product_text_data[0].property_value);
               
        }
        [Fact]
        public void GetProducts_GetProductFilteredByProductDataAndOrderedByName_ListOfProducts()
        {
            //Arrange
            var products = new List<ProductModel>
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
                            property_value = "bbbb"
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
                            property_value = "aaaa"
                        },
                        new ProductTextDataModel
                        {
                            product_id = 2,
                            product_data_id = 5,
                            product_property_name = "data2",
                            property_value = "value 0"
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
                            property_value = "bbbb"
                        },
                        new ProductTextDataModel
                        {
                            product_id = 3,
                            product_data_id = 7,
                            product_property_name = "data2",
                            property_value = "value 1"
                        }
                    }
                }

            }.AsQueryable();

            var productsMock = new Mock<DbSet<ProductModel>>();

            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.Provider).Returns(products.Provider);
            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.Expression).Returns(products.Expression);
            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.ElementType).Returns(products.ElementType);
            productsMock.As<IQueryable<ProductModel>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            List<ProductTextDataModel> productTextData = new();

            productTextData.AddRange(products.AsEnumerable().ToList()[0].product_text_data);
            productTextData.AddRange(products.AsEnumerable().ToList()[1].product_text_data);
            productTextData.AddRange(products.AsEnumerable().ToList()[2].product_text_data);

            var productTextDataMock = new Mock<DbSet<ProductTextDataModel>>();

            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.Provider).Returns(productTextData.AsQueryable().Provider);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.Expression).Returns(productTextData.AsQueryable().Expression);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.ElementType).Returns(productTextData.AsQueryable().ElementType);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().Setup(m => m.GetEnumerator()).Returns(productTextData.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ProductAPIDbContext>();

            dbContextMock.SetupGet(c => c.products).Returns(productsMock.Object);
            dbContextMock.SetupGet(c => c.productsTextData).Returns(productTextDataMock.Object);

            IProductsDbAccess productsDbAccess = new ProductsDbAccess(dbContextMock.Object);


            ProductQueryData productQueryData = new ProductQueryData
            {
                textDataFilter = new Dictionary<string, string>(),
                numericDataFilter = new Dictionary<string, double>()
            };
            productQueryData.textDataFilter.Add("data2", "value 0");
            productQueryData.order = "productName";

            //Act

            List<ProductModel> filteredOrderdProducts = productsDbAccess.GetProducts(productQueryData);

            //Assert
            Assert.Equal(2, filteredOrderdProducts[0].product_id);
            Assert.Equal(1, filteredOrderdProducts[1].product_id);
            Assert.Equal(2, filteredOrderdProducts.Count);


        }

        [Fact]
        public void GetProducts_GetProductsWithEmptyDataObject_RawListOfProducts()
        {
            //Arrange
            var products = new List<ProductModel>
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
                            property_value = "bbbb"
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
                            property_value = "aaaa"
                        },
                        new ProductTextDataModel
                        {
                            product_id = 2,
                            product_data_id = 5,
                            product_property_name = "data2",
                            property_value = "value 0"
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
                            property_value = "bbbb"
                        },
                        new ProductTextDataModel
                        {
                            product_id = 3,
                            product_data_id = 7,
                            product_property_name = "data2",
                            property_value = "value 1"
                        }
                    }
                }

            }.AsQueryable();

            var productsMock = new Mock<DbSet<ProductModel>>();

            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.Provider).Returns(products.Provider);
            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.Expression).Returns(products.Expression);
            productsMock.As<IQueryable<ProductModel>>().SetupGet(m => m.ElementType).Returns(products.ElementType);
            productsMock.As<IQueryable<ProductModel>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            List<ProductTextDataModel> productTextData = new();

            productTextData.AddRange(products.AsEnumerable().ToList()[0].product_text_data);
            productTextData.AddRange(products.AsEnumerable().ToList()[1].product_text_data);
            productTextData.AddRange(products.AsEnumerable().ToList()[2].product_text_data);

            var productTextDataMock = new Mock<DbSet<ProductTextDataModel>>();

            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.Provider).Returns(productTextData.AsQueryable().Provider);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.Expression).Returns(productTextData.AsQueryable().Expression);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().SetupGet(m => m.ElementType).Returns(productTextData.AsQueryable().ElementType);
            productTextDataMock.As<IQueryable<ProductTextDataModel>>().Setup(m => m.GetEnumerator()).Returns(productTextData.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ProductAPIDbContext>();

            dbContextMock.SetupGet(c => c.products).Returns(productsMock.Object);
            dbContextMock.SetupGet(c => c.productsTextData).Returns(productTextDataMock.Object);

            IProductsDbAccess productsDbAccess = new ProductsDbAccess(dbContextMock.Object);


            ProductQueryData productQueryData = new ProductQueryData();

            //Act

            List<ProductModel> filteredOrderdProducts = productsDbAccess.GetProducts(productQueryData);

            //Assert
            Assert.Equal(3, filteredOrderdProducts.Count);
        }
    }
}
