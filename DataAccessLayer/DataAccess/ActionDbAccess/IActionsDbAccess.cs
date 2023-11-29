using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.ActionDbAccess
{
    public interface IActionsDbAccess
    {
        public List<ActionModel> GetURLActions(string urlName);
        public List<ActionModel> GetShopActions(string shopName);
        public void AddURLAction(string urlName, ActionName action_name, List<string> action_data);
        public void AddShopAction(string shopName, ActionName action_name, List<string> action_data);
        public void DeleteURLAction(string urlName, int actionId);
        public void DeleteShopAction(string shopName, int actionId);

    }
}
