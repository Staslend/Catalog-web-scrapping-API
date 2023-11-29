
using PriceAPI.Services.LinksService;
using PriceAPI.Services.PriceApiService;
using PriceAPI.Services.ProductService;
using PriceAPI.Services.ShopNameService;
using PriceAPI.Services.WebScrappingService;
using PriceAPI.Services_new_.ActionService;
using PriceAPI.Services_new_.ProductService;
using PriceAPI.Services_new_.ShopService;
using PriceAPI.Services_new_.URLService;
using PriceAPI.Services_new_.XPathService;

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

            builder.Services.AddScoped<IActionService, ActionService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IShopService, ShopService>();
            builder.Services.AddScoped<IURLService, URLService>();
            builder.Services.AddScoped<IXPathService, XPathService>();

            builder.Services.AddSingleton<IWebScrapper, WebScrapper>();

            builder.Services.AddSingleton<ILinkService, RawLinkService>();
            builder.Services.AddSingleton<IShopNameService, ShopNameService>();

            builder.Services.AddSingleton<IWebScrapper, WebScrapper>();

            builder.Services.AddSingleton<IPriceAPIService, PriceAPIService>();

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