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
    public class ShopsDbAccess : IShopsDbAccess
    {

        ProductAPIDbContext _context;

        public ShopsDbAccess(ProductAPIDbContext context)
        {
            _context = context;
        }

        public async void AddShop(string shopName, string shopDomainName)
        {
            _context.shops.Add(new ShopModel
            {
                shop_name = shopName,
                shop_domain_name = shopDomainName
            });
            await _context.SaveChangesAsync();
        }

        public async void DeleteShop(int shopId)
        {
            ShopModel? shopToDelete = await _context.shops.Include(s => s.actions).Include(u => u.xPaths).AsQueryable().FirstOrDefaultAsync(u => u.shop_id == shopId);

            if (shopToDelete != null)
            {
                _context.shops.Remove(shopToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ShopModel>> GetShops()
        {
            List<ShopModel> returnList;

            returnList = await  _context.shops.ToListAsync();
            return returnList;
        }
    }
}
