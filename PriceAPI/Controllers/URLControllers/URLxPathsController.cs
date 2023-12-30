using DataAccessLayer.DataAccess.XPathDbAccess;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

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
        public async Task<JsonResult> GetXPaths(int URLId)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return new JsonResult(await _xPathDbAccess.GetURLxPaths(URLId), jsonSerializerOptions);
        }
        [HttpPost("urls/{URLId}/xpaths")]
        public async Task AddXPaths(int URLId , string xpath, string property, string atribute)
        {
            await _xPathDbAccess.AddURLxPath(URLId, xpath, property, atribute);
        }
        [HttpDelete("urls/{URLId}/xpaths")]
        public async Task GetXPaths(int URLId, int xpathId)
        {
            await _xPathDbAccess.DeleteURLxPath(URLId, xpathId);
        }
        [HttpPatch("urls/{URLId}/xpaths")]
        public async Task UpdateXPath(int URLId, int xpathId, string newXPath = "", string newProperty = "", string newAtribute = "")
        {
            await _xPathDbAccess.UpdateURLxPath(URLId, xpathId, newXPath, newProperty, newAtribute);
        }
    }
}
