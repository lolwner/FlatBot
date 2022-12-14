using FlatBot.Domain.Entities;

namespace FlatBot.Application.Services
{
    public interface ICitiesManagementService
    {
        public void TestFunc();
        public Task<List<CitySource>> GetCities();
        public void AddSourceToCity(string city, int source);
        public void AddSourceToCity(string city, List<int> source);
        public Task AddCitiesToSourceAsync(int source, List<string> cities);
        public void RemoveCity(string city);
        public void RemoveCitySource(string city, int source);
        public void RemoveCitySource(string city, List<int> source);

    }
}
