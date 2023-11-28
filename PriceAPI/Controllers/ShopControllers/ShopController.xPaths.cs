using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]

    public class ShopxPathsController : ControllerBase
    {
        [HttpGet("shops/{shop_domain_name}/xpaths")]
        public JsonResult GetXPaths(string shop_domain_name)
        {
            //GET ALL XPATHS FUNC
            return new JsonResult("");
        }
        [HttpPost("shops/{shop_domain_name}/xpaths/add")]
        public void AddXPaths(string shop_domain_name, string xpath, string property, string atribute)
        {
            //ADD XPATH FUNC
        }

    }
}
