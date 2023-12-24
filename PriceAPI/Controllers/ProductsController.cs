using DataAccessLayer.DataAccess.ProductsDbAccess;
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


        [HttpGet("products/{id}")]
        public async Task<JsonResult> Products(int id)
        {
            return new JsonResult(_productService.GetProduct(id));
        }

        [HttpGet("products/")]
        public async Task<JsonResult> Products([FromQuery] ProductQueryData productQueryData)
        {
            return new JsonResult(_productService.GetProducts(productQueryData));
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
