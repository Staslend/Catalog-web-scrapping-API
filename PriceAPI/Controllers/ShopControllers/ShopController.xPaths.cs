using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services_new_.XPathService;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]

    public class ShopxPathsController : ControllerBase
    {
        IXPathService _xPathService;
        ShopxPathsController(IXPathService xPathService)
        {
            _xPathService = xPathService;
        }

        [HttpGet("shops/{shop_domain_name}/xpaths")]
        public JsonResult GetXPaths(string shop_domain_name)
        {
            return new JsonResult(_xPathService.GetShopxPaths(shop_domain_name));
        }
        [HttpPost("shops/{shop_domain_name}/xpaths/add")]
        public void AddXPaths(string shop_domain_name, string xpath, string property, string atribute)
        {
            _xPathService.AddShopxPaths(shop_domain_name, xpath, property, atribute);
        }
        [HttpDelete("shops/{shop_domain_name}/xpaths/delete")]
        public void DeleteAction(string shop_domain_name, int xpathId)
        {
            _xPathService.DeleteShopxPaths(shop_domain_name, xpathId);
        }

    }
}
