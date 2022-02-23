using CatFacts.Core.Config;
using CatFacts.Core.Interfaces;
using CatFacts.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatFacts.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFactService, FactService>();
            services.AddScoped<IFileService, FileService>();
        }

        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FactOptions>(configuration.GetSection("Facts"));
        }
    }
}
