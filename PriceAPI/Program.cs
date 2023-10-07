
using PriceAPI.Services.LinksService;
using PriceAPI.Services.PriceApiService;
using PriceAPI.Services.ProductService;
using PriceAPI.Services.WebScrappingService;

namespace PriceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ILinkService, JSONLinksService>();
            builder.Services.AddScoped<IWebScrapper, WebScrapper>();

            builder.Services.AddScoped<IPriceAPIService, PriceAPIService>();

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