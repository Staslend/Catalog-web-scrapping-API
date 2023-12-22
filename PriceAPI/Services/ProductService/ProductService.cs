using DataAccessLayer.DataAccess.ProductsDbAccess;
using DataAccessLayer.DataAccess.URLDbAccess;
using DatabaseLayer.Models;
using PriceAPI.Controllers;
using WebScrapperLayer.WebScrapperDataProvider;

namespace PriceAPI.Services.ProductService
{
    public class ProductService : IProductService
    {
        IProductsDbAccess _productsDbAccess;
        IURLsDbAccess _URLsDataAccess;

        IWebScrapperDataProvider _webScrapperDataProvider;


        public ProductService(IProductsDbAccess productsDbAccess, IURLsDbAccess URLsDbAccess, IWebScrapperDataProvider webScrapperDataProvider)
        {
            _productsDbAccess = productsDbAccess;
            _URLsDataAccess = URLsDbAccess;
            _webScrapperDataProvider = webScrapperDataProvider;
        }

        public ProductModel GetProduct(int productId)
        {
            return _productsDbAccess.GetProduct(productId);
        }

        public List<ProductModel> GetProducts(ProductQueryData productQueryData)
        {
            return _productsDbAccess.GetProducts(productQueryData);
        }

        public void UpdateProducts()
        {
            _productsDbAccess.ClearDbProductData();

            foreach (URLModel url in _URLsDataAccess.GetURLs())

                //TODO: PROPER NULL CHECK

                _productsDbAccess.AddDbProductData(
                    _webScrapperDataProvider.GetProductsData(
                        url.shop is null ? url.xPaths : url.shop.xPaths,
                        url.shop is null ? url.actions : url.shop.actions,
                        url.url)
                );
        }
    }
}
