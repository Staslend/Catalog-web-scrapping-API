using DatabaseLayer.Models;
using DataAccessLayer.DataAccess.XPathDbAccess;

namespace PriceAPI.Services_new_.XPathService
{
    public class XPathService : IXPathService
    {
        IXPathsDbAccess _xPathService;
        XPathService(IXPathsDbAccess xPathService)
        {
            _xPathService = xPathService;
        }

        public void AddShopxPaths(string shopName, string xpath, string property, string atribute)
        {
            _xPathService.AddShopxPaths(shopName, xpath, property, atribute);
        }

        public void AddURLxPaths(string urlName, string xpath, string property, string atribute)
        {
            _xPathService.AddShopxPaths(urlName, xpath, property, atribute);
        }

        public void DeleteShopxPaths(string shopName, int xPathId)
        {
            _xPathService.DeleteShopxPaths(shopName, xPathId);
        }

        public void DeleteURLxPaths(string urlName, int xPathId)
        {
            _xPathService.DeleteURLxPaths(urlName, xPathId);
        }

        public List<XPathModel> GetShopxPaths(string shopName)
        {
            return _xPathService.GetShopxPaths(shopName);
        }

        public List<XPathModel> GetURLxPaths(string urlName)
        {
            return _xPathService.GetURLxPaths(urlName);
        }
    }
}
