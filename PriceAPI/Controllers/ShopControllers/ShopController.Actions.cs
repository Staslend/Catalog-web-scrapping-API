using DataAccessLayer.DataAccess.ActionDbAccess;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]
    public class ShopActionsController : ControllerBase
    {
        IActionsDbAccess _actionsDbAccess;

        public ShopActionsController(IActionsDbAccess actionsDbAccess) 
        { 
            _actionsDbAccess = actionsDbAccess;
        }


        [HttpGet("shops/{shopId}/actions")]
        public async Task<JsonResult> GetActions(int shopId)
        {
            List<ActionModel> actionsToReturn = await _actionsDbAccess.GetShopActions(shopId);

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return new JsonResult(actionsToReturn, jsonSerializerOptions);
        }

        [HttpPost("shops/{shopId}/actions/add")]
        public async Task AddActions(int shopId, ActionName action_name, string action_data)
        {
            await _actionsDbAccess.AddShopAction(shopId, action_name, action_data.Split(',').ToList());
        }

        [HttpDelete("shops/{shopId}/actions/delete")]
        public async Task DeleteAction(int shopId, int actionId)
        {
            await _actionsDbAccess.DeleteShopAction(shopId, actionId);
        }

    }
}
