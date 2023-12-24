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

        public async void AddURL(string URLName, string URL, int shopId)
        {
            ShopModel? shopToAdd = await _context.shops.FindAsync(shopId);

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

            await _context.SaveChangesAsync();

        }

        public async void ChangeURL(int URLId, string newURL)
        {
            URLModel? urlToChange = await _context.URLs.Include(u => u.actions).Include(u => u.xPaths).FirstOrDefaultAsync(u => u.url_id == URLId);

            if (urlToChange != null)
            {
                urlToChange.url = newURL;
                _context.Update(urlToChange);
            }
        }

        public async void DeleteURL(int URLId)
        {
            URLModel? urlToDelete = await _context.URLs.Include(u => u.actions).Include(u => u.xPaths).FirstOrDefaultAsync(u => u.url_id == URLId);

            if (urlToDelete != null)
            {
                _context.URLs.Remove(urlToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<URLModel>> GetURLs()
        {
            List<URLModel> returnList;

            returnList = await _context.URLs.Include(url => url.actions).Include(url=>url.xPaths).Include(url => url.shop).
                Include(url => url.shop.xPaths).Include(url => url.shop.actions).ToListAsync();
            return returnList;
        }
    }
}
