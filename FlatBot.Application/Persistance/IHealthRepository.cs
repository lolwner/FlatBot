namespace FlatBot.Application.Persistance
{
    public interface IHealthRepository
    {
        Task<bool> CheckHealthAsync();
    }
}
