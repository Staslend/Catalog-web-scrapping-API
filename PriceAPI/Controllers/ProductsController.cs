using DataAccessLayer.DataAccess.ProductsDbAccess;
using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services.ProductService;
using PriceAPI.Services.ProductService;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return new JsonResult(await _productService.GetProduct(id), jsonSerializerOptions);
        }

        [HttpGet("products/")]
        public async Task<JsonResult> Products([FromQuery] ProductQueryData productQueryData)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return new JsonResult(await _productService.GetProducts(productQueryData), jsonSerializerOptions);
        }

        //TODO: Bad responce 
        [HttpPatch("products/")]
        public async Task<IActionResult> Update()
        {
            await _productService.UpdateProducts();
            return Ok("Updade started");
        }
    }
}
