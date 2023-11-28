using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services_new_.URLService;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public class URLController : ControllerBase
    {
        IURLService _URLService;

        URLController(IURLService URLService)
        {
            _URLService = URLService;
        }

        [HttpGet("urls/")]
        public JsonResult GetURLs()
        {
            return new JsonResult(_URLService.GetURLs());
        }

        [HttpPost("urls/add/")]
        public void AddURL(string url_name, string url, string shop_domain_name)
        {
            _URLService.AddURL(url_name, url, shop_domain_name);
        }
        [HttpDelete("urls/{url_name}/")]
        public void DeleteURL(string url_name)
        {
            _URLService.DeleteURL(url_name);
        }
        [HttpPatch("urls/{url_name}/")]
        public void ChangeURL(string url_name, string new_url)
        {
            _URLService.ChangeURL(url_name, new_url);
        }
    }
}
