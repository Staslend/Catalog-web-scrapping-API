using DataAccessLayer.DataAccess.ProductsDbAccess;
using DatabaseLayer.Models;
using PriceAPI.Controllers;

namespace PriceAPI.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductModel>> GetProducts(ProductQueryData productQueryData);

        public Task<ProductModel> GetProduct(int productId);
        public Task UpdateProducts();

    }
}
