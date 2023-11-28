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
        public void AddURL(string shop_name, string shop_domain_name)
        {
            //ADD SHOP FUNC
        }
        [HttpDelete("shops/{shop_domain_name}/")]
        public void DeleteShop(string shop_domain_name)
        {
            //DELETE URL FUNC
        }
        [HttpPatch("shops/{shop_id}/")]
        public void ChangeShop(string shop_id, string new_url)
        {
            //CHANGE URL FUNC
        }

    }
}
