using DataAccessLayer.DataAccess.ProductsDbAccess;
using DataAccessLayer.DataAccess.URLDbAccess;
using DatabaseLayer.Models;
using PriceAPI.Controllers;
using System.Text;
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
            {
                if (url.multipaged)
                {
                    StringBuilder urlStringBuilder = new StringBuilder(url.url);

                    for(int pageNumber = 1; true; pageNumber++)
                    {
                        urlStringBuilder.Remove(url.url.Length, urlStringBuilder.Length);
                        urlStringBuilder.Append("/");
                        urlStringBuilder.Append(url.pageProperty);
                        urlStringBuilder.Append(pageNumber);

                        List<ProductModel> newProducts = _webScrapperDataProvider.GetProductsData(
                            url.shop is null ? url.xPaths : url.shop.xPaths,
                            url.shop is null ? url.actions : url.shop.actions,
                            urlStringBuilder.ToString()).Result;

                        if (newProducts is null)
                        {
                            break;
                        }
                        else _productsDbAccess.AddDbProductData(newProducts);

                    }

                }
                else
                {
                    _productsDbAccess.AddDbProductData(
                        _webScrapperDataProvider.GetProductsData(
                            url.shop is null ? url.xPaths : url.shop.xPaths,
                            url.shop is null ? url.actions : url.shop.actions,
                            url.url).Result
                    );

                }
            }

            //TODO: PROPER NULL CHECK

        }
    }
}
