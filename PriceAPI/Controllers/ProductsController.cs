using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services.ProductService;

namespace PriceAPI.Controllers
{
    [Route("/api/[action]")]
    [ApiController]
    public class ProductsController : Controller
    {
        IPriceAPIService _priceApiService;

        public ProductsController(IPriceAPIService priceAPIService)
        {
            _priceApiService = priceAPIService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ProductsWebScrapped(string productName = "")
        {
            var res = await _priceApiService.GetProductsWebScrapped();

            return new JsonResult(res);
        }

        [HttpGet]
        public async Task<JsonResult> Products(string productName = "")
        {
            var res = await _priceApiService.GetProductsFromDb();

            return new JsonResult(res);
        }


        [HttpPut]
        public async Task Update()
        {
            await _priceApiService.UpdateDatabase();
        }
    }
}
