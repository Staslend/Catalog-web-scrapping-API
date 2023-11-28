using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services_new_.ActionService;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public partial class URLActionsController : ControllerBase
    {
        IActionService _actionService;

        URLActionsController(IActionService actionService)
        {
            _actionService = actionService;
        }


        [HttpGet("urls/{url_name}/actions")]
        public JsonResult GetActions(string url_name)
        {

            return new JsonResult(_actionService.GetURLActions(url_name));
        }

        [HttpPost("urls/{url_name}/actions/add")]
        public void AddActions(string url_name, ActionName action_name, [ModelBinder] List<string> action_data)
        {
            _actionService.AddURLAction(url_name, action_name, action_data);
        }

        [HttpDelete("urls/{url_name}/actions/add")]
        public void DeleteAction(string url_name, int actionId)
        {
            _actionService.DeleteURLAction(url_name, actionId);
        }

    }
}
