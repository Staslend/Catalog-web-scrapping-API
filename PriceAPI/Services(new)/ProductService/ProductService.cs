using DataAccessLayer.DataAccess.ProductsDbAccess;
using DataAccessLayer.DataAccess.URLDbAccess;
using DatabaseLayer.Models;
using WebScrapperLayer.WebScrapperDataProvider;

namespace PriceAPI.Services_new_.ProductService
{
    public class ProductService : IProductService
    {
        IProductsDbAccess _productsDbAccess;
        IURLsDbAccess _URLsDataAccess;

        IWebScrapperDataProvider _webScrapperDataProvider;


        ProductService(IProductsDbAccess productsDbAccess, IURLsDbAccess URLsDbAccess, IWebScrapperDataProvider webScrapperDataProvider)
        {
            _productsDbAccess = productsDbAccess;
            _URLsDataAccess = URLsDbAccess;
            _webScrapperDataProvider = webScrapperDataProvider;
        }

        public List<ProductModel> GetProducts(int? page, string orderby = "product_id")
        {
            return _productsDbAccess.GetProducts(page, orderby);
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
