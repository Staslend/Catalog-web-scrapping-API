using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PriceAPI.Services_new_.ActionService;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]

    public class ShopActionsController : ControllerBase
    {
        IActionService _actionService;

        ShopActionsController(IActionService actionService) 
        { 
            _actionService = actionService;
        }


        [HttpGet("shops/{shop_domain_name}/actions")]
        public JsonResult GetActions(string shop_domain_name)
        {
            List<ActionModel> actionsToReturn = _actionService.GetShopActions(shop_domain_name);
            return new JsonResult(actionsToReturn);
        }

        [HttpPost("shops/{shop_domain_name}/actions/add")]
        public void AddActions(string shop_domain_name, ActionName action_name, [ModelBinder] List<string> action_data)
        {
            _actionService.AddShopAction(shop_domain_name, action_name, action_data);
        }

        [HttpDelete("shops/{shop_domain_name}/actions/delete")]
        public void DeleteAction(string shop_domain_name, int actionId)
        {
            _actionService.DeleteShopAction(shop_domain_name, actionId);
        }

    }
}
