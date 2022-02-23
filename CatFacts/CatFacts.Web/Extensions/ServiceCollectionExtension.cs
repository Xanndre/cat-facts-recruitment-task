using CatFacts.Core.Interfaces;
using CatFacts.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatFacts.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFactService, FactService>();
        }
    }
}
