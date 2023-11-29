using DatabaseLayer.Models;
using DataAccessLayer.DataAccess.ActionDbAccess;

namespace PriceAPI.Services_new_.ActionService
{
    public class ActionService : IActionService
    {
        IActionsDbAccess _actionsDbAccess;

        ActionService(IActionsDbAccess actionsDbAccess)
        {
            _actionsDbAccess = actionsDbAccess;
        }
        public void AddShopAction(string shopName, ActionName action_name, List<string> action_data)
        {
            _actionsDbAccess.AddShopAction(shopName, action_name, action_data);
        }

        public void AddURLAction(string urlName, ActionName action_name, List<string> action_data)
        {
            _actionsDbAccess.AddURLAction(urlName, action_name, action_data);
        }

        public void DeleteShopAction(string shopName, int actionId)
        {
            _actionsDbAccess.DeleteShopAction(shopName, actionId);
        }

        public void DeleteURLAction(string urlName, int actionId)
        {
            _actionsDbAccess.DeleteURLAction(urlName, actionId);
        }

        public List<ActionModel> GetShopActions(string shopName)
        {
            return _actionsDbAccess.GetShopActions(shopName);
        }

        public List<ActionModel> GetURLActions(string urlName)
        {
            return _actionsDbAccess.GetURLActions(urlName);
        }
    }
}
