using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DataContexts
{
    public class ProductAPIDbContext : DbContext
    {
        public DbSet<ProductModel> products { get; set; }
        public DbSet<ProductNumericDataModel> productsNumericData { get; set; }
        public DbSet<ProductTextDataModel> productsTextData { get; set; }

        public DbSet<ShopModel> shops { get; set; }
        public DbSet<URLModel> URLs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProductAPIDb");
        }
    }
}
