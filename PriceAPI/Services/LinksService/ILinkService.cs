using PriceAPI.Models;

namespace PriceAPI.Services.LinksService
{
    public enum Shop
    {
        ATB, 
        Silpo,
        Wellmart,
        ECOmarker
    }

    public interface ILinkService
    {
        public Task<List<PageModel>> GetLinks(List<Shop> shops = null);
    }
}
