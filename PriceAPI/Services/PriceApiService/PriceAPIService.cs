using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<JsonDocument> GetJSONProductsWebScrapped(string productName = "", string sorting = "", List<string> shops = null)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            var jsonString = JsonSerializer.SerializeToDocument(GetProductsWebScrapped(), options);

            return jsonString;
        }

        public async Task<JsonDocument> GetJSONProductsFromDb(string productName = "", string sorting = "", List<string> shops = null)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            string query = "SELECT * FROM Products ";

            if(productName != "")
            {
                query += "WHERE Name LIKE '%" + productName + "%'";
            }

            if (shops is not null)
            {

            }

            if(sorting != "")
            {
                query += "order by " + sorting;
            }

            var jsonString = JsonSerializer.SerializeToDocument(GetProductsFromDb(query), options);

            return jsonString;

        }

        public async Task<List<ProductModel>> GetProductsWebScrapped(string productName = "", string sorting = "", List<string> shops = null)
        {
            List<ProductModel> products = new List<ProductModel>();

            List<string> links = await _linkService.GetLinks();

            foreach (string link in links)
            {
                if(link != "") products.AddRange((await _webScrapper.GetProducts(link)));
            }

            return products;
        }

        public async Task<List<ProductModel>> GetProductsFromDb(string query)
        {
            List<ProductModel> returnProducts;
            /*
            using (var context = new LinksContext())
            {
                returnProducts = context.Products.FromSqlRaw(query).ToList();
            }
            */
            //Fixed to make it compile
            return null;
        }

        public async Task UpdateDatabase()
        {
            /*
            using (var context = new LinksContext())
            {
                context.Products.RemoveRange(context.Products);
                await context.Products.AddRangeAsync(await GetProductsWebScrapped());
                await context.SaveChangesAsync();
            }
            */
        }

        Task<List<ProductModel>> IPriceAPIService.GetProductsWebScrapped(string productName, string sorting, List<string> shops)
        {
            throw new NotImplementedException();
        }

        Task<List<ProductModel>> IPriceAPIService.GetProductsFromDb(string query)
        {
            throw new NotImplementedException();
        }
    }
}
