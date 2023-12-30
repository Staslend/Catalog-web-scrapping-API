using DataAccessLayer.DataAccess.ActionDbAccess;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PriceAPI.Controllers.URLControllers
{
    [Route("api/")]
    [ApiController]
    public partial class URLActionsController : ControllerBase
    {
        IActionsDbAccess _actionsDbAccess;

        public URLActionsController(IActionsDbAccess actionsDbAccess)
        {
            _actionsDbAccess = actionsDbAccess;
        }


        [HttpGet("urls/{URLId}/actions")]
        public async Task<JsonResult> GetActions(int URLId)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return new JsonResult(await _actionsDbAccess.GetURLActions(URLId), jsonSerializerOptions);
        }

        [HttpPost("urls/{URLId}/actions/add")]
        public async Task AddActions(int URLId, ActionName action_name, string action_data)
        {
            await _actionsDbAccess.AddURLAction(URLId, action_name, action_data.Split(',').ToList());
        }

        [HttpDelete("urls/{URLId}/actions/add")]
        public async Task DeleteAction(int URLId, int actionId)
        {
            await _actionsDbAccess.DeleteURLAction(URLId, actionId);
        }

    }
}
