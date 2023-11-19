using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    internal interface IShopsDbAccess
    {
        void AddShop(ShopModel shop);
        ShopModel GetShop(string shopId);
    }
}
