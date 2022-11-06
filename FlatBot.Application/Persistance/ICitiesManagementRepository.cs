using FlatBot.Domain.Entities;

namespace FlatBot.Application.Persistance
{
    public interface ICitiesManagementRepository
    {
        public Task AddCity(CitySource city);
        Task AddCitiesToSourceAsync(int source, List<string> cityIds);
    }
}
