using DatabaseLayer.Models;
using DatabaseLayer.DataContexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DataAccessLayer.DataAccess.XPathDbAccess
{
    public class XPathsDbAccess : IXPathsDbAccess
    {
        ProductAPIDbContext _context;

        public XPathsDbAccess(ProductAPIDbContext context)
        {
            _context = context;
        }

        public async Task AddShopxPath(int shopId, string xpath, string property, string atribute)
        {
            XPathModel newXPath = new XPathModel
            {
                xpath = xpath,
                property_name = property,
                atribute = atribute
            };

            ShopModel editedShop = await _context.shops.Where(s => s.shop_id == shopId).Include(s => s.xPaths).FirstAsync();

            if (editedShop != null)
            {
                if (editedShop.xPaths != null)
                {
                    editedShop.xPaths.Add(newXPath);
                }
                else
                {
                    editedShop.xPaths = new List<XPathModel> { newXPath };
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddURLxPath(int URLId, string xpath, string property, string atribute)
        {
            XPathModel newXPath = new XPathModel
            {
                xpath = xpath,
                property_name = property,
                atribute = atribute
            };

            URLModel editedShop = await _context.URLs.Where(url => url.url_id == URLId).Include(s => s.xPaths).FirstAsync();

            if (editedShop != null)
            {
                if (editedShop.xPaths != null)
                {
                    editedShop.xPaths.Add(newXPath);
                }
                else
                {
                    editedShop.xPaths = new List<XPathModel> { newXPath };
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShopxPath(int shopId, int xPathId)
        {
            ShopModel shop = await _context.shops.Include(s => s.xPaths).Where(s => s.shop_id == shopId && s.xPaths != null).FirstAsync();

            if (shop.xPaths != null)
            {
                XPathModel xPath = shop.xPaths.First(xp => xp.xpath_id == xPathId);

                shop.xPaths.Remove(xPath);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteURLxPath(int URLId, int xPathId)
        {
            URLModel url = await _context.URLs.Include(u => u.xPaths).Where(u => u.url_id == URLId && u.xPaths != null).FirstAsync();

            if (url.xPaths != null)
            {
                XPathModel xPath = url.xPaths.First(xp => xp.xpath_id == xPathId);

                url.xPaths.Remove(xPath);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<XPathModel>> GetShopxPaths(int shopId)
        {
            List<XPathModel> returnList;

            ShopModel shop = await _context.shops.Include(s => s.xPaths).Where(s => s.shop_id == shopId && s.xPaths != null).FirstAsync();

            if (shop.xPaths != null)
            {
                returnList = shop.xPaths;
            }
            else returnList = new List<XPathModel>();
            return returnList;
        }

        public async Task<List<XPathModel>> GetURLxPaths(int URLId)
        {
            List<XPathModel> returnList;

            URLModel url = await _context.URLs.Include(u => u.xPaths).Where(u => u.url_id == URLId && u.xPaths != null).FirstAsync();

            if (url.xPaths != null)
            {
                returnList = url.xPaths;
            }
            else returnList = new List<XPathModel>();
            return returnList;
        }

        public async Task UpdateShopxPath(int shopId, int xpathId, string newXPath = "", string newProperty = "", string newAtribute = "")
        {
            ShopModel shop = await _context.shops.Include(s => s.xPaths).Where(s => s.shop_id == shopId && s.xPaths != null).FirstAsync();

            XPathModel xPathToEdit = shop.xPaths.Where(xPath => xPath.xpath_id == xpathId).First();

            if (!newXPath.IsNullOrEmpty())
            {
                xPathToEdit.xpath = newXPath; 
            }

            if(!newProperty.IsNullOrEmpty())
            {
                xPathToEdit.property_name = newProperty;
            }

            if(!newAtribute.IsNullOrEmpty())
            {
                xPathToEdit.atribute = newAtribute;
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateURLxPath(int URLId, int xpathId, string newXPath = "", string newProperty = "", string newAtribute = "")
        {
            URLModel url = await _context.URLs.Include(u => u.xPaths).Where(u => u.url_id == URLId && u.xPaths != null).FirstAsync();

            XPathModel xPathToEdit = url.xPaths.Where(xPath => xPath.xpath_id == xpathId).First();

            if (!newXPath.IsNullOrEmpty())
            {
                xPathToEdit.xpath = newXPath;
            }

            if (!newProperty.IsNullOrEmpty())
            {
                xPathToEdit.property_name = newXPath;
            }

            if (!newAtribute.IsNullOrEmpty())
            {
                xPathToEdit.atribute = newAtribute;
            }
            _context.Update(xPathToEdit);
        }
    }
}
