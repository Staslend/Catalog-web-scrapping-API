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
        public Task<List<ActionModel>> GetURLActions(int URLId);
        public Task<List<ActionModel>> GetShopActions(int shopId);
        public Task AddURLAction(int URLId, ActionName actionName, List<string> actionData);
        public Task AddShopAction(int shopId, ActionName actionName, List<string> actionData);
        public Task DeleteURLAction(int URLId, int actionId);
        public Task DeleteShopAction(int shopId, int actionId);

    }
}
