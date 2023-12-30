using DataAccessLayer.DataAccess.URLDbAccess;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public class URLController : ControllerBase
    {
        IURLsDbAccess _URLsDbAccess;

        public URLController(IURLsDbAccess URLsDbAccess)
        {
            _URLsDbAccess = URLsDbAccess;
        }

        [HttpGet("urls/")]
        public async Task<JsonResult> GetURLs()
        {

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return new JsonResult(await _URLsDbAccess.GetURLs(), jsonSerializerOptions);
        }

        [HttpPost("urls/add/")]
        public async Task AddURL(string url_name, string url, int shopId, bool multipaged)
        {
            await _URLsDbAccess.AddURL(url_name, url, shopId, multipaged);
        }
        [HttpDelete("urls/{URLId}/")]
        public async Task DeleteURL(int URLId)
        {
            await _URLsDbAccess.DeleteURL(URLId);
        }
        [HttpPatch("urls/{URLId}/")]
        public async Task ChangeURL(int URLId, string newURl)
        {
            await _URLsDbAccess.ChangeURL(URLId, newURl);
        }
    }
}
