using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using DatabaseLayer.Models;

namespace PriceAPI.Services.ProductService
{
    public interface IPriceAPIService
    {
        //Functions for use in controllers
        public Task UpdateDatabase();
        public Task<JsonDocument> GetJSONProductsWebScrapped(string productName = "", string sorting = "", List<string> shops = null);
        public Task<JsonDocument> GetJSONProductsFromDb(string productName = "", string sorting = "", List<string> shops = null);

        //Functions for internal use
        public Task<List<ProductModel>> GetProductsWebScrapped(string productName = "", string sorting = "", List<string> shops = null);
        public Task<List<ProductModel>> GetProductsFromDb(string query);







    }
}
