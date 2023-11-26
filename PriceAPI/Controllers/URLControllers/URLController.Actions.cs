using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.URLControllers
{
    [ApiController]
    public partial class URLController : ControllerBase
    {
        [HttpGet("urls/{url_name}/actions")]
        public JsonResult GetActions(string url_name)
        {
            //GET ALL ACTIONS FUNC
            return new JsonResult("");
        }

        [HttpPost("urls/{url_name}/actions/add")]
        public void AddActions(string url_name, ActionName action_name, [ModelBinder] List<string> action_data)
        {
            //ADD NEW ACTION FUNC
        }

    }
}
