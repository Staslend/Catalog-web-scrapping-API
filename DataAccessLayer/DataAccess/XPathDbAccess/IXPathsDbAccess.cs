using DatabaseLayer.Models;

namespace DataAccessLayer.DataAccess.XPathDbAccess
{
    public interface IXPathsDbAccess
    {
        public List<XPathModel> GetURLxPaths(int URLId);
        public List<XPathModel> GetShopxPaths(int shopId);
        public void AddURLxPath(int URLId, string xpath, string property, string atribute);
        public void AddShopxPath(int shopId, string xpath, string property, string atribute);
        public void DeleteURLxPath(int URLId, int xPathId);
        public void DeleteShopxPath(int shopId, int xPathId);

    }
}
