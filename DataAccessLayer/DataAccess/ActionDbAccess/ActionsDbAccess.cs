using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.ActionDbAccess
{
    public class ActionsDbAccess : IActionsDbAccess
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
