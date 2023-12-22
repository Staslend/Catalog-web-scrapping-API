using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DataContexts
{
    public class ProductAPIDbContext : DbContext
    {
        public virtual DbSet<ProductModel> products { get; set; }
        public virtual DbSet<ProductNumericDataModel> productsNumericData { get; set; }
        public virtual DbSet<ProductTextDataModel> productsTextData { get; set; }

        public virtual DbSet<ShopModel> shops { get; set; }
        public virtual DbSet<URLModel> URLs { get; set; }


        public ProductAPIDbContext() { }

        public ProductAPIDbContext(DbContextOptions options) : base(options)
        {
        
        }
    }
}
