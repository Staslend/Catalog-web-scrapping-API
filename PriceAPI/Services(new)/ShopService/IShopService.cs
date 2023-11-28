using DatabaseLayer.Models;

namespace PriceAPI.Services_new_.ShopService
{
    public interface IShopService
    {
        public List<ShopModel> GetShops();
        public void AddShop(string shop_name, string shop_domain_name);
        public void DeleteShop(string shop_domain_name);

    }
}
