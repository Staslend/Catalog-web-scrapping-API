namespace PriceAPI.Services.ShopNameService
{
    public interface IShopNameService
    {
        string GetShopName(string link);
        void AddNewShop(string domain, string name);
    }
}
