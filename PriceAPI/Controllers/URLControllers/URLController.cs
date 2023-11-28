using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public class URLController : ControllerBase
    {

        [HttpGet("urls/")]
        public JsonResult GetURLs()
        {
            //GET ALL URLS FUNC
            return new JsonResult("");
        }

        [HttpPost("urls/add/")]
        public void AddURL(string url_name, string url, string shop_domain_name)
        {
            //ADD URL FUNC
        }
        [HttpDelete("urls/{url_name}/")]
        public void DeleteURL(string url_name)
        {
            //DELETE URL FUNC
        }
        [HttpPatch("urls/{url_name}/")]
        public void ChangeURL(string url_name, string new_url)
        {
            //CHANGE URL FUNC
        }
    }
}
