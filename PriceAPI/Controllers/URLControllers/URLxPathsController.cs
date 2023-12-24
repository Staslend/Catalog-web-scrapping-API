using DataAccessLayer.DataAccess.XPathDbAccess;
using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public class URLxPathController : ControllerBase
    {

        IXPathsDbAccess _xPathDbAccess;
        public URLxPathController(IXPathsDbAccess xPathDbAccess)
        {
            _xPathDbAccess = xPathDbAccess;
        }


        [HttpGet("urls/{URLId}/xpaths")]
        public JsonResult GetXPaths(int URLId)
        {
            return new JsonResult(_xPathDbAccess.GetURLxPaths(URLId));
        }
        [HttpPost("urls/{URLId}/xpaths")]
        public void AddXPaths(int URLId , string xpath, string property, string atribute)
        {
            _xPathDbAccess.AddURLxPath(URLId, xpath, property, atribute);
        }
        [HttpDelete("urls/{URLId}/xpaths")]
        public void GetXPaths(int URLId, int xpathId)
        {
            _xPathDbAccess.DeleteURLxPath(URLId, xpathId);
        }
        [HttpPatch("urls/{URLId}/xpaths")]
        public void UpdateXPath(int URLId, int xpathId, string newXPath = "", string newProperty = "", string newAtribute = "")
        {
            _xPathDbAccess.UpdateURLxPath(URLId, xpathId, newXPath, newProperty, newAtribute);
        }
    }
}
