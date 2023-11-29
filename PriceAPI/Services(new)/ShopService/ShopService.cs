using DatabaseLayer.Models;
using DataAccessLayer.DataAccess.ShopDbAccess;

namespace PriceAPI.Services_new_.ShopService
{
    public class ShopService : IShopService
    {
        IShopsDbAccess _shopDbAccess;

        ShopService(IShopsDbAccess shopDbAccess)
        {
            _shopDbAccess = shopDbAccess;
        }

        public void AddShop(string shop_name, string shop_domain_name)
        {
            _shopDbAccess.AddShop(shop_name, shop_domain_name);
        }

        public void DeleteShop(string shop_domain_name)
        {
            _shopDbAccess.DeleteShop(shop_domain_name);
        }

        public List<ShopModel> GetShops()
        {
            return _shopDbAccess.GetShops();
        }
    }
}
