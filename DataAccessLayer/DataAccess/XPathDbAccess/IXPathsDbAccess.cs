using DatabaseLayer.Models;

namespace DataAccessLayer.DataAccess.XPathDbAccess
{
    public interface IXPathsDbAccess
    {
        public Task<List<XPathModel>> GetURLxPaths(int URLId);
        public Task<List<XPathModel>> GetShopxPaths(int shopId);
        public Task AddURLxPath(int URLId, string xpath, string property, string atribute);
        public Task AddShopxPath(int shopId, string xpath, string property, string atribute);
        public Task DeleteURLxPath(int URLId, int xPathId);
        public Task DeleteShopxPath(int shopId, int xPathId);
        public Task UpdateURLxPath(int URLId, int xpathId, string newXPath = "", string newProperty = "", string newAtribute = "");
        public Task UpdateShopxPath(int shopId, int xpathId, string newXPath = "", string newProperty = "", string newAtribute = "");
    }
}
