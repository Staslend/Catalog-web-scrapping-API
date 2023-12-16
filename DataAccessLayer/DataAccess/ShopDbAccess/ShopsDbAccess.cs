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

        ProductAPIDbContext _context;

        ShopsDbAccess(ProductAPIDbContext context)
        {
            _context = context;
        }

        public void AddShop(string shopName, string shopDomainName)
        {
            _context.shops.Add(new ShopModel
            {
                shop_name = shopName,
                shop_domain_name = shopDomainName
            });
            _context.SaveChanges();
        }

        public void DeleteShop(int shopId)
        {
            ShopModel? shopToDelete = _context.shops.Include(s => s.actions).Include(u => u.xPaths).FirstOrDefault(u => u.shop_id == shopId);

            if (shopToDelete != null)
            {
                _context.shops.Remove(shopToDelete);
                _context.SaveChanges();
            }
        }

        public List<ShopModel> GetShops()
        {
            List<ShopModel> returnList;

            returnList = _context.shops.ToList();
            return returnList;
        }
    }
}
