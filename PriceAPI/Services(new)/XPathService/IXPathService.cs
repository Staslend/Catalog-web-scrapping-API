﻿using DatabaseLayer.Models;

namespace PriceAPI.Services_new_.XPathService
{
    public interface IXPathService
    {
        public List<XPathModel> GetURLxPaths(string urlName);
        public List<XPathModel> GetShopxPaths(string shopName);
        public void AddURLxPaths(string urlName, string xpath, string property, string atribute);
        public void AddShopxPaths(string shopName, string xpath, string property, string atribute);
        public void DeleteURLxPaths(string urlName, int xPathId);
        public void DeleteShopxPaths(string shopName, int xPathId);

    }
}