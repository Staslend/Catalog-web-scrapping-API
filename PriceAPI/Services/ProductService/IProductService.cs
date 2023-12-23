using DataAccessLayer.DataAccess.ProductsDbAccess;
using DatabaseLayer.Models;
using PriceAPI.Controllers;

namespace PriceAPI.Services.ProductService
{
    public interface IProductService
    {
        public List<ProductModel> GetProducts(ProductQueryData productQueryData);

        public ProductModel GetProduct(int productId);
        public void UpdateProducts();

    }
}
