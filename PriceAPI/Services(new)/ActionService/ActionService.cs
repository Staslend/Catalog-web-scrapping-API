using DatabaseLayer.Models;

namespace PriceAPI.Services_new_.ActionService
{
    public class ActionService : IActionService
    {
        public void AddShopAction(string shopName, ActionName action_name, List<string> action_data)
        {
            throw new NotImplementedException();
        }

        public void AddURLAction(string urlName, ActionName action_name, List<string> action_data)
        {
            throw new NotImplementedException();
        }

        public void DeleteShopAction(string shopName, int actionId)
        {
            throw new NotImplementedException();
        }

        public void DeleteURLAction(string urlName, int actionId)
        {
            throw new NotImplementedException();
        }

        public List<ActionModel> GetShopActions(string shopName)
        {
            throw new NotImplementedException();
        }

        public List<ActionModel> GetURLActions(string urlName)
        {
            throw new NotImplementedException();
        }
    }
}
