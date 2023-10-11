using System.Text.Json;

namespace PriceAPI.Services.ShopNameService
{
    public class ShopNameService : IShopNameService
    {
        Dictionary<string, string> _shopNames = new Dictionary<string, string>();

        public ShopNameService()
        {
            var jsonfile = File.ReadAllBytes("ShopName.json");

            //_shopNames = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonfile);

            _shopNames.Add("atbmarket.com", "АТБ");
            _shopNames.Add("eko.zakaz.ua", "ЕКОмаркет");

        }

        public void AddNewShop(string domain, string name)
        {
            _shopNames.Add(domain, name);
            var json = JsonSerializer.Serialize(_shopNames);

            File.WriteAllText("ShopNames.json", json);
        }

        public string GetShopName(string link)
        {
            foreach(KeyValuePair<string, string> kp  in _shopNames)
            {
                if(link.Contains(kp.Key)) return kp.Value;
            }
            return "Shop";
        }
    }
}
