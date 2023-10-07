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

        public async Task<JsonDocument> GetProducts(string name = " ")
        {
            List<ProductModel> products = new List<ProductModel>();

            List<PageModel> pml = await _linkService.GetLinks();

            foreach (PageModel pm in pml)
            {
                products.AddRange((await _webScrapper.GetProducts(pm)));
            }

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            var jsonString = JsonSerializer.SerializeToDocument(products, options);

            return jsonString;
        }
    }
}
