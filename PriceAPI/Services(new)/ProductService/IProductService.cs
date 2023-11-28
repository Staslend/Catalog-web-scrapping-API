using DatabaseLayer.Models;

namespace PriceAPI.Services_new_.ProductService
{
    public interface IProductService
    {
        public List<ProductModel> GetProducts(int page = -1);
        public void UpdateProducts();

    }
}
