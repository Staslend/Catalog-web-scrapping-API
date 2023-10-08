using Microsoft.AspNetCore.Mvc.RazorPages;
using PriceAPI.Models;
using System.Text.Json;

namespace PriceAPI.Services.ProductService
{
    public interface IPriceAPIService
    {
        //Functions for use in controllers
        public Task UpdateDatabase();
        public Task<JsonDocument> GetJSONProductsWebScrapped();
        public Task<JsonDocument> GetJSONProductsFromDb();

        //Functions for internal use
        public Task<List<ProductModel>> GetProductsWebScrapped(string name = " ");
        public Task<List<ProductModel>> GetProductsFromDb(string name = " ");







    }
}
