using FlatBot.Application.Mappers;
using FlatBot.Application.Scrapers;
using FlatBot.Application.Services;
using FlatBot.Infrastructure.Mappers;
using FlatBot.Infrastructure.Scrapers;
using FlatBot.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlatBot.Infrastructure
{
    public static class ApplicationInfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IOLXScraper, OLXScraper>();
            services.AddTransient<IOLXMapper, OLXMapper>();

            services.AddTransient<IOLXService, OLXService>();
            services.AddTransient<IOLXLinkBuilderService, OLXLinkBuilderService>();

            services.AddTransient<IHealthService, HealthService>();
            services.AddTransient<ICitiesManagementService, CitiesManagementService>();

            return services;
        }

    }
}
