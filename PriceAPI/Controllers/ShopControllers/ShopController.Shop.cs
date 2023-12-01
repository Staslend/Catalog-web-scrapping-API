using DataAccessLayer.DataAccess.ShopDbAccess;
using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IShopsDbAccess _shopsDbAccess;
        ShopController(IShopsDbAccess shopsDbAccess) {
            _shopsDbAccess = shopsDbAccess;
        }

        [HttpGet("shops/")]
        public JsonResult GetShops()
        {
            
            return new JsonResult(_shopsDbAccess.GetShops());
        }

        [HttpPost("shops/add/")]
        public void AddShop(string shop_name, string shop_domain_name)
        {
            _shopsDbAccess.AddShop(shop_name, shop_domain_name);
        }

        [HttpDelete("shops/{shopId}/")]
        public void DeleteShop(int shopId)
        {
            _shopsDbAccess.DeleteShop(shopId);
        }

    }
}
