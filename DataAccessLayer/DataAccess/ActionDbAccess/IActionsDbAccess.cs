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
        public List<ActionModel> GetURLActions(int URLId);
        public List<ActionModel> GetShopActions(int shopId);
        public void AddURLAction(int URLId, ActionName actionName, List<string> actionData);
        public void AddShopAction(int shopId, ActionName actionName, List<string> actionData);
        public void DeleteURLAction(int URLId, int actionId);
        public void DeleteShopAction(int shopId, int actionId);

    }
}
