using DatabaseLayer.DataContexts;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.DataAccess.ActionDbAccess
{
    public class ActionsDbAccess : IActionsDbAccess
    {
        public void AddShopAction(int shopId, ActionName actionName, List<string> actionData)
        {
            ActionModel newAction = new ActionModel
            {
                action_name = actionName,
                action_data = actionData.Select(data => new ActionDataModel()
                {
                    action_data = data
                }).ToList(),
            };

            using (var context = new ProductAPIDbContext())
            {
                ShopModel editedShop = context.shops.Where(s => s.shop_id == shopId).Include(s => s.actions).First();

                if (editedShop != null)
                {
                    if (editedShop.actions != null)
                    {
                        editedShop.actions.Add(newAction);
                    }
                    else
                    {
                        editedShop.actions = new List<ActionModel> { newAction };
                    }
                }
                context.SaveChanges();
            }
        }

        public void AddURLAction(int URLId, ActionName actionName, List<string> actionData)
        {
            ActionModel newAction = new ActionModel
            {
                action_name = actionName,
                action_data = actionData.Select(data => new ActionDataModel()
                {
                    action_data = data
                }).ToList(),
            };

            using (var context = new ProductAPIDbContext())
            {
                URLModel url = context.URLs.Include(u => u.actions).Where(u => u.url_id == URLId && u.xPaths != null).First();

                if (url != null)
                {
                    if (url.actions != null)
                    {
                        url.actions.Add(newAction);
                    }
                    else
                    {
                        url.actions = new List<ActionModel> { newAction };
                    }
                }
                context.SaveChanges();
            }
        }

        public void DeleteShopAction(int shopId, int actionId)
        {
            using (var context = new ProductAPIDbContext())
            {
                ShopModel shop = context.shops.Include(s => s.actions).Where(s => s.shop_id == shopId && s.xPaths != null).First();

                if (shop.actions != null)
                {
                    ActionModel action = shop.actions.First(a => a.action_id == actionId);

                    shop.actions.Remove(action);

                    context.SaveChanges();
                }
            }
        }

        public void DeleteURLAction(int URLId, int actionId)
        {
            using (var context = new ProductAPIDbContext())
            {
                URLModel url = context.URLs.Include(u => u.actions).Where(u => u.url_id == URLId && u.xPaths != null).First();

                if (url.xPaths != null)
                {
                    XPathModel xPath = url.xPaths.First(xp => xp.xpath_id == URLId);

                    url.xPaths.Remove(xPath);

                    context.SaveChanges();
                }
            }
        }

        public List<ActionModel> GetShopActions(int shopId)
        {
            List<ActionModel> returnList;

            using (var context = new ProductAPIDbContext())
            {
                ShopModel shop = context.shops.Include(u => u.actions).Where(u => u.shop_id == shopId && u.actions != null).First();

                if (shop.actions != null)
                {
                    returnList = shop.actions;
                }
                else returnList = new List<ActionModel>();
            }
            return returnList;
        }

        public List<ActionModel> GetURLActions(int URLId)
        {
            List<ActionModel> returnList;

            using (var context = new ProductAPIDbContext())
            {
                URLModel url = context.URLs.Include(u => u.actions).Where(u => u.url_id == URLId && u.actions != null).First();

                if (url.actions != null)
                {
                    returnList = url.actions;
                }
                else returnList = new List<ActionModel>();
            }
            return returnList;
        }
    }
}
