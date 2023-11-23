using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DataContexts
{
    internal class ProductAPIDbContext : DbContext
    {
        public DbSet<ProductModel> products { get; set; }
        public DbSet<ShopModel> shops { get; set; }
        public DbSet<XPathModel> xpaths { get; set; }
        public DbSet<ActionModel> actions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProductAPIDb");
        }
    }
}
