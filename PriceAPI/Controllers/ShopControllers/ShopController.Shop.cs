using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services_new_.ShopService;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IShopService _shopService;
        ShopController(IShopService shopService) {
            _shopService = shopService;
        }

        [HttpGet("shops/")]
        public JsonResult GetShops()
        {
            
            return new JsonResult(_shopService.GetShops());
        }

        [HttpPost("shops/add/")]
        public void AddShop(string shop_name, string shop_domain_name)
        {
            _shopService.AddShop(shop_name, shop_domain_name);
        }

        [HttpDelete("shops/{shop_domain_name}/")]
        public void DeleteShop(string shop_domain_name)
        {
            _shopService.DeleteShop(shop_domain_name);
        }

    }
}
