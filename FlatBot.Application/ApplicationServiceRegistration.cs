using FlatBot.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlatBot.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            

            return services;
        }
    }
}
