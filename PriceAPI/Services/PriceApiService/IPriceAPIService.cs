using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace PriceAPI.Services.ProductService
{
    public interface IPriceAPIService
    {
        public  Task<JsonDocument> GetProducts(string name = " ");
    }
}
