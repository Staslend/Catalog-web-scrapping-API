using PriceAPI.Models;
using System.Text.Json;

namespace PriceAPI.Services.LinksService
{
    public class JSONLinksService : ILinkService
    {
        public async Task<List<PageModel>> GetLinks(List<Shop> shops = null)
        {
            //FileStream fileStream = new FileStream("ShopLinks.json", FileMode.Open);
            //var sr = new StreamReader(fileStream);
            //LinksPack lp = JsonSerializer.Deserialize<LinksPack>(sr.ReadToEnd());


            var jsonfile = File.ReadAllBytes("ShopLinks.json");

            List<PageModel> list = JsonSerializer.Deserialize<List<PageModel>>(jsonfile);
            return list;
        }
    }
}
