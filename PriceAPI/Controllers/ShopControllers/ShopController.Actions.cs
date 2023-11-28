using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]

    public class ShopActionsController : ControllerBase
    {
        [HttpGet("shops/{shop_domain_name}/actions")]
        public JsonResult GetActions(string shop_domain_name)
        {
            //GET ALL ACTIONS FUNC
            return new JsonResult("");
        }

        [HttpPost("shops/{shop_domain_name}/actions/add")]
        public void AddActions(string shop_domain_name, ActionName action_name, [ModelBinder] List<string> action_data)
        {
            //ADD NEW ACTION FUNC
        }

        [HttpDelete("shops/{shop_domain_name}/actions/delete")]
        public void DeleteAction(string shop_domain_name, int actionId)
        {
            //DELETE FUNCTION
        }

    }
}
