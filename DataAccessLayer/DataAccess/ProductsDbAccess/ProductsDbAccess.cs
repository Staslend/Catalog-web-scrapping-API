using DatabaseLayer.DataContexts;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataAccess.ProductsDbAccess
{

    public class ProductQueryData
    {
        public int page = 0;
        public int pageSize = 0;

        public string keyWord = string.Empty;
        public string order = string.Empty;
        public Dictionary<string, string> textDataFilter = new();
        public Dictionary<string, double> numericDataFilter = new();

    }

    public class ProductsDbAccess : IProductsDbAccess
    {
        ProductAPIDbContext _context;

        public ProductsDbAccess(ProductAPIDbContext productAPIDbContext)
        {
            _context = productAPIDbContext;
        }

        public async Task AddDbProductData(List<ProductModel> products)
        {
            _context.products.AttachRange(products);
            await _context.SaveChangesAsync();
        }

        public async Task ClearDbProductData()
        {

            _context.products.RemoveRange(_context.products);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductModel> GetProduct(int productId)
        {
            ProductModel? product;
            product = await  _context.products.Include(p => p.product_text_data).Include(p => p.product_numeric_data).FirstAsync(p => p.product_id == productId);

            if (product == null)
            {
                product = new ProductModel();
            }
            return product;
        }

        public async Task<List<ProductModel>> GetProducts(ProductQueryData productQueryData)
        {
            IQueryable<ProductModel> returnProducQuery = _context.products;

            var testList1 = returnProducQuery.ToList();


            //Filtering
            if (productQueryData.textDataFilter.Count != 0 || productQueryData.numericDataFilter.Count != 0)
            {
                IQueryable<int> productIdsFilteredByTextFilters = null;
                IQueryable<int> productIdsFilteredByNumericFilters = null;


                if (_context.productsTextData is not null && productQueryData.textDataFilter is not null)
                {
                    productIdsFilteredByTextFilters = _context.productsTextData.Select(p =>
                    new
                    {
                        id = p.product_id,
                        keyPair = new KeyValuePair<string, string>(p.product_property_name, p.property_value)
                    }
                    ).Where(p => productQueryData.textDataFilter.Contains(p.keyPair)).GroupBy(p => p.id).Select(p => new
                    {
                        id = p.Key,
                        count = p.Count()
                    }).Where(p => p.count >= productQueryData.textDataFilter.Count).Select(p => p.id);
                }
                if (_context.productsNumericData is not null && productQueryData.numericDataFilter is not null)
                {
                    productIdsFilteredByNumericFilters = _context.productsNumericData.Select(p =>
                    new
                    {
                        id = p.product_id,
                        keyPair = new KeyValuePair<string, double>(p.product_property_name, p.property_value)
                    }
                    ).Where(p => productQueryData.numericDataFilter.Contains(p.keyPair)).GroupBy(p => p.id).Select(p => new
                    {
                        id = p.Key,
                        count = p.Count()
                    }).Where(p => p.count >= productQueryData.textDataFilter.Count).Select(p => p.id);
                }

                if (productIdsFilteredByNumericFilters is not null && productIdsFilteredByTextFilters is not null)
                {
                    returnProducQuery = returnProducQuery.Select(p => p).Where(p => productIdsFilteredByNumericFilters.Intersect(productIdsFilteredByTextFilters).Contains(p.product_id));
                }
                else if (productIdsFilteredByNumericFilters is null && productIdsFilteredByTextFilters is not null)
                {
                    returnProducQuery = returnProducQuery.Select(p => p).Where(p => productIdsFilteredByTextFilters.Contains(p.product_id));
                }
                else if (productIdsFilteredByNumericFilters is not null && productIdsFilteredByTextFilters is null)
                {
                    returnProducQuery = returnProducQuery.Select(p => p).Where(p => productIdsFilteredByNumericFilters.Contains(p.product_id));
                }
            }

            var testList2 = returnProducQuery.ToList();

            //Ordering
            if (!string.IsNullOrEmpty(productQueryData.order))
            {
                returnProducQuery = from product in returnProducQuery
                                    join productTextData in _context.productsTextData
                                    on new { id = product.product_id, @productQueryData.order } equals
                                       new { id = productTextData.product_id, order = productTextData.product_property_name } into grouping
                                    from x in grouping.DefaultIfEmpty()
                                    orderby x.property_value
                                    select new ProductModel { product_id = x.product_id };
            }

            var testList3 = returnProducQuery.ToList();

            //Paggination
            if (productQueryData.page != 0 && productQueryData.pageSize != 0)
            {
                returnProducQuery.Skip(productQueryData.page * productQueryData.pageSize).Take(productQueryData.pageSize).ToList();
            }


            //Loading
            List<ProductModel> returnList = returnProducQuery.ToList();

            for(int i = 0; i < returnList.Count; i++)
            {
                returnList[i] =  _context.products.Select(p => p).Where(p => p.product_id == returnList[i].product_id).
                    Include(p => p.product_text_data).Include(p => p.product_numeric_data).First();
            }

            /*
            foreach (ProductModel product in returnList)
            {
                var e = _context.Entry(product);


                if (_context.Entry(product).Collection(p => p.product_text_data) is not null)
                {
                    await _context.Entry(product).Collection(p => p.product_text_data).LoadAsync();
                }
                if (_context.Entry(product).Collection(p => p.product_numeric_data) is not null)
                {
                    await _context.Entry(product).Collection(p => p.product_numeric_data).LoadAsync();
                }
            }
            */


            return returnList;

        }
    }
}
