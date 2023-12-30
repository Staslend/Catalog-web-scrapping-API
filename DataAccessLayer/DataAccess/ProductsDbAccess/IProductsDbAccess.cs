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
        public Task ClearDbProductData();
        public Task AddDbProductData(List<ProductModel> products);
        Task<List<ProductModel>> GetProducts(ProductQueryData productQueryData);
        Task<ProductModel> GetProduct(int productId);
    }
}
