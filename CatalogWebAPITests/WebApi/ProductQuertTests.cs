using DataAccessLayer.DataAccess.ActionDbAccess;
using DataAccessLayer.DataAccess.ProductsDbAccess;
using DataAccessLayer.DataAccess.ShopDbAccess;
using DataAccessLayer.DataAccess.URLDbAccess;
using DataAccessLayer.DataAccess.XPathDbAccess;
using DatabaseLayer.DataContexts;
using Moq;
using PriceAPI.Controllers;
using PriceAPI.Controllers.ShopControllers;
using PriceAPI.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapperLayer.WebScrapperDataProvider;

namespace CatalogWebAPITests.WebApiTests
{
    public class ProductQuertTests
    {
        [Fact]
        public void GetProducts_GetFullListOfWebScrapperProduct()
        {
            //Arrange
            var contextMock = new Mock<ProductAPIDbContext>();

            ProductsDbAccess productsDbAccess = new ProductsDbAccess(contextMock.Object);
            URLsDbAccess URLsDbAccess = new URLsDbAccess(contextMock.Object);
            ShopsDbAccess shopsDbAccess = new ShopsDbAccess(contextMock.Object);
            ActionsDbAccess actionsDbAccess = new ActionsDbAccess(contextMock.Object);
            XPathsDbAccess xPathsDbAccess = new XPathsDbAccess(contextMock.Object);

            WebScrapperDataProvider webScrapperDataProvider = new WebScrapperDataProvider();

            ProductService productService = new ProductService(productsDbAccess, URLsDbAccess, webScrapperDataProvider);

            ProductsController productsController = new ProductsController(productService);

            ShopController shopController = new ShopController(shopsDbAccess);
            ShopActionsController shopActionsController = new ShopActionsController(actionsDbAccess);
            ShopxPathsController shopxPathsController = new ShopxPathsController(xPathsDbAccess);
           
            //Act

            //Assert
        }
    }
}
