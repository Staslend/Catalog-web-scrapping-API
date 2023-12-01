using DataAccessLayer.DataAccess.XPathDbAccess;
using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]

    public class ShopxPathsController : ControllerBase
    {
        IXPathsDbAccess _XPathdDbAccess;
        ShopxPathsController(IXPathsDbAccess XPathdDbAccess)
        {
            _XPathdDbAccess = XPathdDbAccess;
        }

        [HttpGet("shops/{shopId}/xpaths")]
        public JsonResult GetXPaths(int shopId)
        {
            return new JsonResult(_XPathdDbAccess.GetShopxPaths(shopId));
        }
        [HttpPost("shops/{shopId}/xpaths/add")]
        public void AddXPaths(int shopId, string xpath, string property, string atribute)
        {
            _XPathdDbAccess.AddShopxPath(shopId, xpath, property, atribute);
        }
        [HttpDelete("shops/{shopId}/xpaths/delete")]
        public void DeleteAction(int shopId, int xpathId)
        {
            _XPathdDbAccess.DeleteShopxPath(shopId, xpathId);
        }

    }
}
