namespace FlatBot.Application.Services
{
    public interface IHealthService
    {
        public Task<bool> CheckHealthAsync();

    }
}
