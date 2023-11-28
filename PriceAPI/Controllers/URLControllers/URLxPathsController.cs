using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public class URLxPathController : ControllerBase
    {
        [HttpGet("urls/{url_name}/xpaths")]
        public JsonResult GetXPaths(string url_name)
        {
            //GET ALL XPATHS FUNC
            return new JsonResult("");
        }
        [HttpPost("urls/{url_name}/xpaths/add")]
        public void AddXPaths(string url_name, string xpath, string property, string atribute)
        {
            //ADD XPATH FUNC
        }

    }
}
