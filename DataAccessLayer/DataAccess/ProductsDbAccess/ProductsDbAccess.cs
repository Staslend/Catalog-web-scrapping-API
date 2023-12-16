using Azure;
using DatabaseLayer.DataContexts;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.ProductsDbAccess
{


    public class ProductsDbAccess : IProductsDbAccess
    {
        ProductAPIDbContext _context;

        const int PAGE_SIZE = 100;

        ProductsDbAccess(ProductAPIDbContext productAPIDbContext)
        {
            _context = productAPIDbContext;
        }


        public void AddDbProductData(List<ProductModel> products)
        {
            _context.products.AttachRange(products);
            _context.SaveChanges();
        }

        public void ClearDbProductData()
        {

            _context.products.RemoveRange(_context.products);
            _context.SaveChanges();
        }

        public ProductModel GetProduct(int productId)
        {
            ProductModel? product;
            product = _context.products.Include(p => p.product_text_data).Include(p => p.product_numeric_data).FirstOrDefault(p => p.product_id == productId);

            if (product == null)
            {
                product = new ProductModel();
            }
            return product;
        }

        public List<ProductModel> GetProducts(int? page, string orderby = "")
        {
            List<ProductModel> returnProductList = new();

            if (orderby == string.Empty)
            {
                if (page is null)
                {
                    returnProductList = _context.products.ToList();
                }
                else returnProductList = _context.products.Skip(page.Value * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            }
            else
            {
                var queryWithListOfRequestedProducts = from product in _context.products
                                                       join productTextData in _context.productsTextData
                                                       on new { id = product.product_id, order = @orderby } equals
                                                          new { id = productTextData.product_id, order = productTextData.product_property_name } into grouping
                                                       from x in grouping.DefaultIfEmpty()
                                                       orderby x.property_value
                                                       select new ProductModel { product_id = x.product_id };

                if (page is null)
                {

                    var queryWithFinalList = (from objA in _context.products
                                              join objB in queryWithListOfRequestedProducts on objA.product_id equals objB.product_id
                                              select objA);

                    returnProductList = queryWithFinalList.ToList();
                }
                else
                {
                    var queryWithFinalList = (from objA in _context.products
                                              join objB in queryWithListOfRequestedProducts on objA.product_id equals objB.product_id
                                              select objA).Skip(page.Value * PAGE_SIZE).Take(PAGE_SIZE);

                    returnProductList = queryWithFinalList.ToList();

                }

            }
            return returnProductList;

        }
    }
}
