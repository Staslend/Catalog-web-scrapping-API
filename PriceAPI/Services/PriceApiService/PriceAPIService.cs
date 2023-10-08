using PriceAPI.Database;
using PriceAPI.Models;
using PriceAPI.Services.LinksService;
using PriceAPI.Services.ProductService;
using PriceAPI.Services.WebScrappingService;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace PriceAPI.Services.PriceApiService
{
    public class PriceAPIService : IPriceAPIService
    {
        ILinkService _linkService;
        IWebScrapper _webScrapper;
        public PriceAPIService(ILinkService linkService, IWebScrapper webScrapper)
        {
            _linkService = linkService;
            _webScrapper = webScrapper;
        }

        public async Task<JsonDocument> GetJSONProductsWebScrapped()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            var jsonString = JsonSerializer.SerializeToDocument(GetProductsWebScrapped(), options);

            return jsonString;
        }

        public async Task<JsonDocument> GetJSONProductsFromDb()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            var jsonString = JsonSerializer.SerializeToDocument(GetProductsFromDb(), options);

            return jsonString;

        }

        public async Task<List<ProductModel>> GetProductsWebScrapped(string name = " ")
        {
            List<ProductModel> products = new List<ProductModel>();

            List<PageModel> pml = await _linkService.GetLinks();

            foreach (PageModel pm in pml)
            {
                products.AddRange((await _webScrapper.GetProducts(pm)));
            }

            return products;
        }

        public async Task<List<ProductModel>> GetProductsFromDb(string name = " ")
        {
            List<ProductModel> returnProducts;
            using (var context = new LinksContext())
            {
                returnProducts = context.Products.ToList();
            }
            return returnProducts;
        }

        public async Task UpdateDatabase()
        {
            using (var context = new LinksContext())
            {
                context.Products.RemoveRange(context.Products);
                await context.Products.AddRangeAsync(await GetProductsWebScrapped());
                await context.SaveChangesAsync();
            }
        }
    }
}
