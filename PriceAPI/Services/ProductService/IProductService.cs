using DatabaseLayer.Models;

namespace PriceAPI.Services.ProductService
{
    public interface IProductService
    {
        public List<ProductModel> GetProducts(int? page, string? orderby = "product_id");
        public void UpdateProducts();

    }
}
