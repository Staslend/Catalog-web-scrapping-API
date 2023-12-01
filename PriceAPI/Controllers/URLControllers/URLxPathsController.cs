using DataAccessLayer.DataAccess.XPathDbAccess;
using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services_new_.XPathService;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public class URLxPathController : ControllerBase
    {

        IXPathsDbAccess _xPathDbAccess;
        URLxPathController(IXPathsDbAccess xPathDbAccess)
        {
            _xPathDbAccess = xPathDbAccess;
        }


        [HttpGet("urls/{URLId}/xpaths")]
        public JsonResult GetXPaths(int URLId)
        {
            return new JsonResult(_xPathDbAccess.GetURLxPaths(URLId));
        }
        [HttpPost("urls/{URLId}/xpaths/add")]
        public void AddXPaths(int URLId , string xpath, string property, string atribute)
        {
            _xPathDbAccess.AddURLxPath(URLId, xpath, property, atribute);
        }
        [HttpDelete("urls/{URLId}/xpaths")]
        public void GetXPaths(int URLId, int xpathId)
        {
            _xPathDbAccess.DeleteURLxPath(URLId, xpathId);
        }

    }
}
