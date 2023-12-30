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
        ProductAPIDbContext _context;
        public ActionsDbAccess(ProductAPIDbContext context)
        {
            _context = context;
        }

        public async Task AddShopAction(int shopId, ActionName actionName, List<string> actionData)
        {
            ActionModel newAction = new ActionModel
            {
                action_name = actionName,
                action_data = actionData.Select(data => new ActionDataModel()
                {
                    action_data = data
                }).ToList(),
            };

            ShopModel editedShop = await _context.shops.Where(s => s.shop_id == shopId).Include(s => s.actions).FirstAsync();

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
            await _context.SaveChangesAsync();

        }

        public async Task AddURLAction(int URLId, ActionName actionName, List<string> actionData)
        {
            ActionModel newAction = new ActionModel
            {
                action_name = actionName,
                action_data = actionData.Select(data => new ActionDataModel()
                {
                    action_data = data
                }).ToList(),
            };

            URLModel url = await _context.URLs.Include(u => u.actions).Where(u => u.url_id == URLId && u.xPaths != null).FirstAsync();

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
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShopAction(int shopId, int actionId)
        {
            ShopModel shop = await _context.shops.Include(s => s.actions).Where(s => s.shop_id == shopId && s.xPaths != null).FirstAsync();

            if (shop.actions != null)
            {
                ActionModel action =  shop.actions.First(a => a.action_id == actionId);

                shop.actions.Remove(action);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteURLAction(int URLId, int actionId)
        {
            URLModel url = await _context.URLs.Include(u => u.actions).Where(u => u.url_id == URLId && u.xPaths != null).FirstAsync();

            if (url.xPaths != null)
            {
                XPathModel xPath = url.xPaths.First(xp => xp.xpath_id == URLId);

                url.xPaths.Remove(xPath);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ActionModel>> GetShopActions(int shopId)
        {
            List<ActionModel> returnList;

            ShopModel shop = await _context.shops.Include(u => u.actions).ThenInclude(a => a.action_data).Where(u => u.shop_id == shopId && u.actions != null).FirstAsync();

            if (shop.actions != null)
            {
                returnList = shop.actions;
            }
            else returnList = new List<ActionModel>();
            return returnList;
        }

        public async Task<List<ActionModel>> GetURLActions(int URLId)
        {
            List<ActionModel> returnList;

            URLModel url = await _context.URLs.Include(u => u.actions).Where(u => u.url_id == URLId && u.actions != null).FirstAsync();

            if (url.actions != null)
            {
                returnList = url.actions;
            }
            else returnList = new List<ActionModel>();
            return returnList;
        }
    }
}
