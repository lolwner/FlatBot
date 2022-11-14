using FlatBot.Application.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlatBot.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<WebAppDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            //services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOlxRepository, OlxRepository>();
            services.AddScoped<IHealthRepository, HealthRepository>();
            services.AddScoped<ICitiesManagementRepository, CitiesManagementRepository>();

            //return services;
        }
    }
}
