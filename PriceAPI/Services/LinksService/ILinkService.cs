
namespace PriceAPI.Services.LinksService
{
    public interface ILinkService
    {
        public Task<List<string>> GetLinks();
    }
}
