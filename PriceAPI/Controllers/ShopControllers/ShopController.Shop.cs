using DataAccessLayer.DataAccess.ShopDbAccess;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IShopsDbAccess _shopsDbAccess;
        public ShopController(IShopsDbAccess shopsDbAccess) {
            _shopsDbAccess = shopsDbAccess;
        }

        [HttpGet("shops")]
        public async Task<JsonResult> GetShops()
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return new JsonResult(await _shopsDbAccess.GetShops(), jsonSerializerOptions);
        }

        [HttpPost("shops/add")]
        public async Task AddShop(string shop_name, string shop_domain_name)
        {
            await _shopsDbAccess.AddShop(shop_name, shop_domain_name);
        }

        [HttpDelete("shops/{shopId}")]
        public async Task DeleteShop(int shopId)
        {
            await _shopsDbAccess.DeleteShop(shopId);
        }

    }
}
