using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        [HttpGet("shops/")]
        public JsonResult GetShops()
        {
            //GET ALL SHOPS FUNC
            return new JsonResult("");
        }

        [HttpPost("shops/add/")]
        public void AddShop(string shop_name, string shop_domain_name)
        {
            //ADD SHOP FUNC
        }
        [HttpDelete("shops/{shop_domain_name}/")]
        public void DeleteShop(string shop_domain_name)
        {
            //DELETE URL FUNC
        }

    }
}
