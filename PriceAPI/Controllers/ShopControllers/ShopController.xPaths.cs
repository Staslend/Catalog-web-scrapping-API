using DataAccessLayer.DataAccess.XPathDbAccess;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]
    public class ShopxPathsController : ControllerBase
    {
        IXPathsDbAccess _XPathdDbAccess;
        public ShopxPathsController(IXPathsDbAccess XPathdDbAccess)
        {
            _XPathdDbAccess = XPathdDbAccess;
        }

        [HttpGet("shops/{shopId}/xpaths")]
        public async Task<JsonResult> GetXPaths(int shopId)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return new JsonResult(await _XPathdDbAccess.GetShopxPaths(shopId), jsonSerializerOptions);
        }
        [HttpPost("shops/{shopId}/xpaths/add")]
        public async Task AddXPaths(int shopId, string xpath, string property, string atribute = "")
        {
            await _XPathdDbAccess.AddShopxPath(shopId, xpath, property, atribute);
        }
        [HttpDelete("shops/{shopId}/xpaths/delete")]
        public async Task DeleteAction(int shopId, int xpathId)
        {
            await _XPathdDbAccess.DeleteShopxPath(shopId, xpathId);
        }

        [HttpPatch("shops/{shopId}/xpaths")]
        public async Task UpdateXPath(int shopId, int xpathId, string newXPath = "", string newProperty = "", string newAtribute = "")
        {
            await _XPathdDbAccess.UpdateShopxPath(shopId, xpathId, newXPath, newProperty, newAtribute);
        }


    }
}
