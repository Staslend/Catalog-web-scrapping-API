using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.ProductsDbAccess
{
    public interface IProductsDbAccess
    {
        public void ClearDbProductData();
        public void AddDbProductData(List<ProductModel> products);
        List<ProductModel> GetProducts(int? page, string orderby = "");
        ProductModel GetProduct(int productId);
    }
}
