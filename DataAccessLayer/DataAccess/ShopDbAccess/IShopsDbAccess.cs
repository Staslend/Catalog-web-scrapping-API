using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.ShopDbAccess
{
    public interface IShopsDbAccess
    {
        public Task<List<ShopModel>> GetShops();
        public Task AddShop(string shopName, string shopDomainName);
        public Task DeleteShop(int shopId);
    }
}
