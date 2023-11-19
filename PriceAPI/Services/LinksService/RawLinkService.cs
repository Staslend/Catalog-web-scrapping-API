
namespace PriceAPI.Services.LinksService
{
    public class RawLinkService : ILinkService
    {
        public async Task<List<string>> GetLinks()
        {
            string[] links = await File.ReadAllLinesAsync("ShopLinks.txt");

            return links.ToList();
        }
    }
}
