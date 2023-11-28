using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services_new_.XPathService;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public class URLxPathController : ControllerBase
    {

        IXPathService _xPathService;
        URLxPathController(IXPathService xPathService)
        {
            _xPathService = xPathService;
        }


        [HttpGet("urls/{url_name}/xpaths")]
        public JsonResult GetXPaths(string url_name)
        {
            return new JsonResult(_xPathService.GetURLxPaths(url_name));
        }
        [HttpPost("urls/{url_name}/xpaths/add")]
        public void AddXPaths(string url_name, string xpath, string property, string atribute)
        {
            _xPathService.AddURLxPaths(url_name, xpath, property, atribute);
        }
        [HttpDelete("urls/{url_name}/xpaths")]
        public void GetXPaths(string url_name, int xpathId)
        {
            _xPathService.DeleteURLxPaths(url_name, xpathId);
        }

    }
}
