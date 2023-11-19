using System.Text.Json;

namespace PriceAPI.Services.LinksService
{
    public class JSONLinksService : ILinkService
    {
        public async Task<List<string>> GetLinks()
        {
            var jsonfile = File.ReadAllBytes("ShopLinks.json");

            List<PageModel> list = JsonSerializer.Deserialize<List<PageModel>>(jsonfile);
            
            return null;
        }
    }
}
