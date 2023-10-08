using Microsoft.EntityFrameworkCore;
using PriceAPI.Models;
using System.Data.Common;

namespace PriceAPI.Database
{

    public class LinksContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KURIMASUTANAKA;Initial Catalog=ProductsDb;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
