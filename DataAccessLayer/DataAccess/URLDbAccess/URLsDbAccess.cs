using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.URLDbAccess
{
    public class URLsDbAccess : IURLsDbAccess
    {
        public void AddURL(string url_name, string url, string shop_domain_name)
        {
            throw new NotImplementedException();
        }

        public void ChangeURL(string url_name, string new_url)
        {
            throw new NotImplementedException();
        }

        public void DeleteURL(string url_name)
        {
            throw new NotImplementedException();
        }

        public List<URLModel> GetURLs()
        {
            throw new NotImplementedException();
        }
    }
}
