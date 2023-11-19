
using PriceAPI.Services.LinksService;
using PriceAPI.Services.PriceApiService;
using PriceAPI.Services.ProductService;
using PriceAPI.Services.ShopNameService;
using PriceAPI.Services.WebScrappingService;

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