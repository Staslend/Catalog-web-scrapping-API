using DataAccessLayer.DataAccess.URLDbAccess;
using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services_new_.URLService;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public class URLController : ControllerBase
    {
        IURLsDbAccess _URLsDbAccess;

        URLController(IURLsDbAccess URLsDbAccess)
        {
            _URLsDbAccess = URLsDbAccess;
        }

        [HttpGet("urls/")]
        public JsonResult GetURLs()
        {
            return new JsonResult(_URLsDbAccess.GetURLs());
        }

        [HttpPost("urls/add/")]
        public void AddURL(string url_name, string url, int shopId)
        {
            _URLsDbAccess.AddURL(url_name, url, shopId);
        }
        [HttpDelete("urls/{URLId}/")]
        public void DeleteURL(int URLId)
        {
            _URLsDbAccess.DeleteURL(URLId);
        }
        [HttpPatch("urls/{URLId}/")]
        public void ChangeURL(int URLId, string newURl)
        {
            _URLsDbAccess.ChangeURL(URLId, newURl);
        }
    }
}
