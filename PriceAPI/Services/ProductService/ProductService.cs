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

        List<ProductModel> _previousProductList;

        public ProductService(IProductsDbAccess productsDbAccess, IURLsDbAccess URLsDbAccess, IWebScrapperDataProvider webScrapperDataProvider)
        {
            _productsDbAccess = productsDbAccess;
            _URLsDataAccess = URLsDbAccess;
            _webScrapperDataProvider = webScrapperDataProvider;
        }

        public async Task<ProductModel> GetProduct(int productId)
        {
            return await _productsDbAccess.GetProduct(productId);
        }

        public async Task<List<ProductModel>> GetProducts(ProductQueryData productQueryData)
        {
            return await _productsDbAccess.GetProducts(productQueryData);
        }

        public async Task UpdateProducts()
        {
            await _productsDbAccess.ClearDbProductData();

            foreach (URLModel url in await _URLsDataAccess.GetURLs())
            {
                if (url.multipaged)
                {
                    StringBuilder urlStringBuilder = new StringBuilder(url.url);

                    for(int pageNumber = 1; true; pageNumber++)
                    {
                        if(urlStringBuilder.Length != url.url.Length) urlStringBuilder.Remove(url.url.Length, urlStringBuilder.Length - url.url.Length);
                        urlStringBuilder.Append("/");
                        urlStringBuilder.Append(url.pageProperty);
                        urlStringBuilder.Append(pageNumber);

                        bool sameDataWasLoaded = false;
                        List<ProductModel> newProducts = _webScrapperDataProvider.GetProductsData(
                            url.shop is null ? url.xPaths : url.shop.xPaths,
                            url.shop is null ? url.actions : url.shop.actions,
                            urlStringBuilder.ToString()).Result;

                        if (_previousProductList is not null && _previousProductList.SequenceEqual(newProducts, new ProductComparer()))
                        {
                            break;
                        }
                        else
                        {
                            _previousProductList = new List<ProductModel>(newProducts);
                            _productsDbAccess.AddDbProductData(newProducts);
                        }
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
