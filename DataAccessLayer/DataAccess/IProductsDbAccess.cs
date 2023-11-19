using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    internal interface IProductsDbAccess
    {
        public void ClearDbProductData();
        public void AddDbProductData(List<ProductModel> products);
        List<ProductModel> GetProducts(int page);
    }
}
