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
        public List<ShopModel> GetShops();
        public void AddShop(string shopName, string shopDomainName);
        public void DeleteShop(int shopId);
    }
}
