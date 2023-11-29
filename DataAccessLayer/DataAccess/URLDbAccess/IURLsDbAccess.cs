using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.URLDbAccess
{
    public interface IURLsDbAccess
    {
        public List<URLModel> GetURLs();
        public void AddURL(string url_name, string url, string shop_domain_name);
        public void DeleteURL(string url_name);
        public void ChangeURL(string url_name, string new_url);

    }
}
