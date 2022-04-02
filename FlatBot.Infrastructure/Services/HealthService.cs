using FlatBot.Application.Persistance;
using FlatBot.Application.Services;

namespace FlatBot.Infrastructure.Services
{
    public class HealthService : IHealthService
    {
        private readonly IHealthRepository _healthRepository;

        public HealthService(IHealthRepository healthRepository)
        {
            _healthRepository = healthRepository;
        }

        public async Task<bool> CheckHealthAsync()
        {
            return await _healthRepository.CheckHealthAsync();
        }
    }
}
