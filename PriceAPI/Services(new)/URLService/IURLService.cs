using DatabaseLayer.Models;

namespace PriceAPI.Services_new_.URLService
{
    public interface IURLService
    {
        public List<URLModel> GetURLs();
        public void AddURL(string url_name, string url, string shop_domain_name);
        public void DeleteURL(string url_name);
        public void ChangeURL(string url_name, string new_url);
    }
}
