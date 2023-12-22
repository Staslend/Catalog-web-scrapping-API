using DatabaseLayer.DataContexts;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.URLDbAccess
{
    public class URLsDbAccess : IURLsDbAccess
    {

        ProductAPIDbContext _context;

        public URLsDbAccess(ProductAPIDbContext context)
        {
            _context = context;
        }

        public void AddURL(string URLName, string URL, int shopId)
        {
            ShopModel? shopToAdd = _context.shops.Find(shopId);

            if (shopToAdd == null)
            {
                shopToAdd = new ShopModel
                {
                    shop_domain_name = ""
                };
            }

            _context.URLs.Add(new URLModel
            {
                url = URL,
                url_name = URLName,
                shop = shopToAdd,
                shop_id = shopId
            });

            _context.SaveChanges();

        }

        public void ChangeURL(int URLId, string newURL)
        {
            URLModel? urlToChange = _context.URLs.Include(u => u.actions).Include(u => u.xPaths).FirstOrDefault(u => u.url_id == URLId);

            if (urlToChange != null)
            {
                urlToChange.url = newURL;
                _context.Update(urlToChange);
            }
        }

        public void DeleteURL(int URLId)
        {
            URLModel? urlToDelete = _context.URLs.Include(u => u.actions).Include(u => u.xPaths).FirstOrDefault(u => u.url_id == URLId);

            if (urlToDelete != null)
            {
                _context.URLs.Remove(urlToDelete);
                _context.SaveChanges();
            }
        }

        public List<URLModel> GetURLs()
        {
            List<URLModel> returnList;

            returnList = _context.URLs.ToList();
            return returnList;
        }
    }
}
