using DatabaseLayer.Models;
using DatabaseLayer.DataContexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataAccess.XPathDbAccess
{
    public class XPathsDbAccess : IXPathsDbAccess
    {
        public void AddShopxPath(int shopId, string xpath, string property, string atribute)
        {
            XPathModel newXPath = new XPathModel
            {
                xpath = xpath,
                property_name = property,
                atribute = atribute
            };

            using (var context = new ProductAPIDbContext())
            {
                ShopModel editedShop = context.shops.Where(s => s.shop_id == shopId).Include(s => s.xPaths).First();

                if (editedShop != null)
                {
                    if(editedShop.xPaths != null)
                    {
                        editedShop.xPaths.Add(newXPath);
                    } else
                    {
                        editedShop.xPaths = new List<XPathModel> { newXPath };
                    }
                }
                context.SaveChanges();
            }
        }

        public void AddURLxPath(int URLId, string xpath, string property, string atribute)
        {
            XPathModel newXPath = new XPathModel
            {
                xpath = xpath,
                property_name = property,
                atribute = atribute
            };

            using (var context = new ProductAPIDbContext())
            {
                URLModel editedShop = context.URLs.Where(url => url.url_id == URLId).Include(s => s.xPaths).First();

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
                context.SaveChanges();
            }
        }

        public void DeleteShopxPath(int shopId, int xPathId)
        {
            using (var context = new ProductAPIDbContext())
            {
                ShopModel shop = context.shops.Include(s => s.xPaths).Where(s => s.shop_id == shopId && s.xPaths != null).First();

                if(shop.xPaths != null)
                {
                    XPathModel xPath = shop.xPaths.First(xp => xp.xpath_id == xPathId);

                    shop.xPaths.Remove(xPath);

                    context.SaveChanges();
                }
            }
        }

        public void DeleteURLxPath(int URLId, int xPathId)
        {
            using (var context = new ProductAPIDbContext())
            {
                URLModel url = context.URLs.Include(u => u.xPaths).Where(u => u.url_id == URLId && u.xPaths != null).First();

                if (url.xPaths != null)
                {
                    XPathModel xPath = url.xPaths.First(xp => xp.xpath_id == xPathId);

                    url.xPaths.Remove(xPath);

                    context.SaveChanges();
                }
            }
        }

        public List<XPathModel> GetShopxPaths(int shopId)
        {
            List<XPathModel> returnList;

            using (var context = new ProductAPIDbContext())
            {
                ShopModel shop = context.shops.Include(s => s.xPaths).Where(s => s.shop_id == shopId && s.xPaths != null).First();

                if (shop.xPaths != null)
                {
                    returnList = shop.xPaths;
                }
                else returnList = new List<XPathModel>();
            }
            return returnList;
        }

        public List<XPathModel> GetURLxPaths(int URLId)
        {
            List<XPathModel> returnList;

            using (var context = new ProductAPIDbContext())
            {
                URLModel url = context.URLs.Include(u => u.xPaths).Where(u => u.url_id == URLId && u.xPaths != null).First();

                if(url.xPaths != null)
                {
                    returnList = url.xPaths;
                } else returnList = new List<XPathModel>();
            }
            return returnList;
        }
    }
}
