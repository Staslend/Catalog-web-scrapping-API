using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.URLControllers
{
    public partial class URLController : ControllerBase
    {
        [HttpGet("urls/{url_name}/xpaths")]
        public JsonResult GetXPaths(string url_name)
        {
            //GET ALL XPATHS FUNC
            return new JsonResult("");
        }
        [HttpPost("urls/{url_name}/xpaths/add")]
        public void AddXPaths(string url_name)
        {
            //ADD XPATH FUNC
        }

    }
}
