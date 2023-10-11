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
        public async Task<JsonResult> ProductsWebScrapped(string productName = "", string sorting = "", List<string> shops = null)
        {
            var res = await _priceApiService.GetProductsWebScrapped();

            return new JsonResult(res);
        }

        [HttpGet]
        public async Task<JsonResult> Products(string productName = "", string sorting = "", List<string> shops = null)
        {
            var res = await _priceApiService.GetJSONProductsFromDb(productName, sorting, shops);

            return new JsonResult(res);
        }

        //TODO: Bad responce 
        [HttpPut]
        public async Task<IActionResult> Update()
        {   
            await _priceApiService.UpdateDatabase();
            return Ok("Updade started");
        }
    }
}
