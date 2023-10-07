using PriceAPI.Models;

namespace PriceAPI.Services.LinksService
{
    public class HardcodedLinks : ILinkService
    {
        public Task<List<PageModel>> GetLinks(List<Shop> shops = null)
        {
            List<PageModel> retList = new List<PageModel>(new List<PageModel>
            {
                new PageModel
                {
                    shop = "АТБ",
                    link = "https://www.atbmarket.com/catalog/287-ovochi-ta-frukti?page=",
                    pages = 3
                }
                ,
                new PageModel
                {
                    shop = "АТБ",
                    link = "https://www.atbmarket.com/catalog/322-zamorozheni-produkti?page=",
                    pages = 4
                }
                ,
                new PageModel
                {
                    shop = "АТБ",
                    link = "https://www.atbmarket.com/catalog/343-m-yaso-ta-yaytsya?page=",
                    pages = 2
                }
            });

            return Task.FromResult(retList);
        }
    }
}
