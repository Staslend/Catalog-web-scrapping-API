using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services.ProductService;
using PriceAPI.Services.ProductService;

namespace PriceAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products/")]
        public async Task<JsonResult> Products(int? page, string orderby ="")
        {
            return new JsonResult(_productService.GetProducts(page));
        }

        //TODO: Bad responce 
        [HttpPatch("products/")]
        public async Task<IActionResult> Update()
        {   
            _productService.UpdateProducts();
            return Ok("Updade started");
        }
    }
}
