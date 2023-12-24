using DataAccessLayer.DataAccess.ActionDbAccess;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public JsonResult GetActions(int URLId)
        {

            return new JsonResult(_actionsDbAccess.GetURLActions(URLId));
        }

        [HttpPost("urls/{URLId}/actions/add")]
        public void AddActions(int URLId, ActionName action_name, [ModelBinder] List<string> action_data)
        {
            _actionsDbAccess.AddURLAction(URLId, action_name, action_data);
        }

        [HttpDelete("urls/{URLId}/actions/add")]
        public void DeleteAction(int URLId, int actionId)
        {
            _actionsDbAccess.DeleteURLAction(URLId, actionId);
        }

    }
}
