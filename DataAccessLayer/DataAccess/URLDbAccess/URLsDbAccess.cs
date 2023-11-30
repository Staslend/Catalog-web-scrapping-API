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
        public void AddURL(string URLName, string URL, int shopId)
        {
            using (var context = new ProductAPIDbContext())
            {
                ShopModel? shopToAdd = context.shops.Find(shopId);

                if (shopToAdd == null)
                {
                    shopToAdd = new ShopModel
                    {
                        shop_domain_name = ""
                    };
                }

                context.URLs.Add(new URLModel
                {
                    url = URL,
                    url_name = URLName,
                    shop = shopToAdd,
                    shop_id = shopId
                });

                context.SaveChanges();
            }
        }

        public void ChangeURL(int URLId, string newURL)
        {
            using (var context = new ProductAPIDbContext())
            {
                URLModel? urlToChange = context.URLs.Include(u => u.actions).Include(u => u.xPaths).FirstOrDefault(u => u.url_id == URLId);

                if (urlToChange != null)
                {
                    urlToChange.url = newURL;
                    context.Update(urlToChange);
                }
            }
        }

        public void DeleteURL(int URLId)
        {
            using (var context = new ProductAPIDbContext())
            {
                URLModel? urlToDelete = context.URLs.Include(u => u.actions).Include(u => u.xPaths).FirstOrDefault(u => u.url_id == URLId);

                if(urlToDelete != null)
                {
                    context.URLs.Remove(urlToDelete);
                    context.SaveChanges();
                }

            }
        }

        public List<URLModel> GetURLs()
        {
            List<URLModel> returnList;

            using (var context = new ProductAPIDbContext())
            {
                returnList = context.URLs.ToList();
            }
            return returnList;
        }
    }
}
