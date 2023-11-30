using DatabaseLayer.DataContexts;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.ShopDbAccess
{
    internal class ShopsDbAccess : IShopsDbAccess
    {
        public void AddShop(string shopName, string shopDomainName)
        {
            using (var context = new ProductAPIDbContext())
            {
                context.shops.Add(new ShopModel
                {
                    shop_name = shopName,  
                    shop_domain_name = shopDomainName
                });
                context.SaveChanges();
            }
        }

        public void DeleteShop(int shopId)
        {
            using (var context = new ProductAPIDbContext())
            {
                ShopModel? shopToDelete = context.shops.Include(s => s.actions).Include(u => u.xPaths).FirstOrDefault(u => u.shop_id == shopId);

                if (shopToDelete != null)
                {
                    context.shops.Remove(shopToDelete);
                    context.SaveChanges();
                }
            }
        }

        public List<ShopModel> GetShops()
        {
            List<ShopModel> returnList;

            using (var context = new ProductAPIDbContext())
            {
                returnList = context.shops.ToList();
            }
            return returnList;
        }
    }
}
