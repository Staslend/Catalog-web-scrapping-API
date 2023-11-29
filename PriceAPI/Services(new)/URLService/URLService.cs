using DatabaseLayer.Models;
using DataAccessLayer.DataAccess.XPathDbAccess;
using DataAccessLayer.DataAccess.URLDbAccess;

namespace PriceAPI.Services_new_.URLService
{
    public class URLService : IURLService
    {
        IURLsDbAccess _URLDbAccess;

        URLService(IURLsDbAccess URLDbAccess)
        {
            _URLDbAccess = URLDbAccess;
        }

        public void AddURL(string url_name, string url, string shop_domain_name)
        {
            _URLDbAccess.AddURL(url_name, url, shop_domain_name);
        }

        public void ChangeURL(string url_name, string new_url)
        {
            _URLDbAccess.ChangeURL(url_name, new_url);
        }

        public void DeleteURL(string url_name)
        {
            _URLDbAccess.DeleteURL(url_name);
        }

        public List<URLModel> GetURLs()
        {
            return _URLDbAccess.GetURLs();
;        }
    }
}
