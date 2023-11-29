using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.XPathDbAccess
{
    public class XPathsDbAccess : IXPathsDbAccess
    {
        public void AddShopxPaths(string shopName, string xpath, string property, string atribute)
        {
            throw new NotImplementedException();
        }

        public void AddURLxPaths(string urlName, string xpath, string property, string atribute)
        {
            throw new NotImplementedException();
        }

        public void DeleteShopxPaths(string shopName, int xPathId)
        {
            throw new NotImplementedException();
        }

        public void DeleteURLxPaths(string urlName, int xPathId)
        {
            throw new NotImplementedException();
        }

        public List<XPathModel> GetShopxPaths(string shopName)
        {
            throw new NotImplementedException();
        }

        public List<XPathModel> GetURLxPaths(string urlName)
        {
            throw new NotImplementedException();
        }
    }
}
