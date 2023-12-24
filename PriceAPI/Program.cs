
using DataAccessLayer.DataAccess.ActionDbAccess;
using DataAccessLayer.DataAccess.ProductsDbAccess;
using DataAccessLayer.DataAccess.ShopDbAccess;
using DataAccessLayer.DataAccess.URLDbAccess;
using DataAccessLayer.DataAccess.XPathDbAccess;
using DatabaseLayer.DataContexts;
using Microsoft.EntityFrameworkCore;
using PriceAPI.Services.ProductService;
using WebScrapperLayer.WebScrapperDataProvider;

namespace PriceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("PythonDLLPath", "C:\\Users\\Kurimasu Tanaka\\AppData\\Local\\Programs\\Python\\Python311\\python311.dll");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProductAPIDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            });

            builder.Services.AddTransient<IProductsDbAccess, ProductsDbAccess>();


            builder.Services.AddTransient<IShopsDbAccess, ShopsDbAccess>();
            builder.Services.AddTransient<IURLsDbAccess, URLsDbAccess>();
            builder.Services.AddTransient<IXPathsDbAccess, XPathsDbAccess>();
            builder.Services.AddTransient<IActionsDbAccess, ActionsDbAccess>();



            builder.Services.AddTransient<IProductService, ProductService>();

            builder.Services.AddSingleton<IWebScrapperDataProvider, WebScrapperDataProvider>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}