using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using Mapster;
using Tshop.Data.Data;
using Tshop.Data.Models;
using Tshop.Data.DTO.Response;
using Tshop.Data.Repository;
using Tshop.BLL.Service;

namespace Tshop.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controllers
            builder.Services.AddControllers();

            // OpenAPI
            builder.Services.AddOpenApi();

            // DB Context
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefualtConnection")
                );
            });

            // Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "");

            const string defaultCulture = "en";
            var supportedCultures = new[]
            {
                new CultureInfo(defaultCulture),
                new CultureInfo("ar")
            };

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders.Clear();
                options.RequestCultureProviders.Add(
                    new AcceptLanguageHeaderRequestCultureProvider()
                );
            });

            // ? MAPSTER CONFIGURATION (THE IMPORTANT FIX)
            TypeAdapterConfig<CategoryTranslate, CategoryTranslationResponse>
                .NewConfig()
                .Map(dest => dest.language, src => src.Language);

            TypeAdapterConfig<Category, CategoryResponse>
                .NewConfig()
                .Map(dest => dest.translations, src => src.translations);


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            var app = builder.Build();

            app.UseRequestLocalization(
                app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value
            );

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}