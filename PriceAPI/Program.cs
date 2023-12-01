
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

            builder.Services.AddScoped<IProductService, ProductService>();

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