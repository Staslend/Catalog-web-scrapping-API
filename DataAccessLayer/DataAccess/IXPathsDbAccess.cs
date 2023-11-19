using DatabaseLayer.Models;

namespace DataAccessLayer.DataAccess
{
    internal interface IXPathsDbAccess
    {
        void AddXPaths(List<XPathModel> xpaths);
        void AddXPaths(XPathModel xpath);

    }
}
