using PriceAPI.Models;

namespace PriceAPI.Services.WebScrappingService
{
    public interface IWebScrapper
    {
        public Task<List<ProductModel>> GetProducts(string link);
    }
}
