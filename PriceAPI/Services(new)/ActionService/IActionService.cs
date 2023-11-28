using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Services_new_.ActionService
{
    public interface IActionService
    {
        public List<ActionModel> GetURLActions(string urlName);
        public List<ActionModel> GetShopActions(string shopName);
        public void AddURLAction(string urlName, ActionName action_name,  List<string> action_data);
        public void AddShopAction(string shopName, ActionName action_name,  List<string> action_data);
        public void DeleteURLAction(string urlName, int actionId);
        public void DeleteShopAction(string shopName, int actionId);

    }
}
