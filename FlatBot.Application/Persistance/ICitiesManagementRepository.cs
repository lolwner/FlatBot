using FlatBot.Domain.Entities;

namespace FlatBot.Application.Persistance
{
    public interface ICitiesManagementRepository
    {
        public Task AddCity(CitySource city);
        public Task<List<CitySource>> GetCities();
        Task AddCitiesToSourceAsync(int source, List<string> cityIds);
    }
}
