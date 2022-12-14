using FlatBot.Application.Persistance;
using FlatBot.Application.Services;
using FlatBot.Domain.Entities;
using FlatBot.Infrastructure.Models;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Globalization;

namespace FlatBot.Infrastructure.Services
{
    public class CitiesManagementService : ICitiesManagementService
    {
        private readonly ICitiesManagementRepository _citiesManagementRepository;
        public CitiesManagementService(ICitiesManagementRepository citiesManagementRepository)
        {
            _citiesManagementRepository = citiesManagementRepository;
        }

        public async Task AddCitiesToSourceAsync(int source, List<string> cities)
        {
            await _citiesManagementRepository.AddCitiesToSourceAsync(source, cities);
        }

        public void AddCity(string city, string country)
        {
            var newCity = new CitySource
            {
                Id = ObjectId.GenerateNewId().ToString(),
                CityName = city,
                Country = new Country { CountryName = country }
            };

            _citiesManagementRepository.AddCity(newCity);
        }

        public void AddSourceToCity(string city, int source)
        {
            throw new NotImplementedException();
        }

        public void AddSourceToCity(string city, List<int> source)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CitySource>> GetCities()
        {
            return await _citiesManagementRepository.GetCities();
        }

        public void RemoveCity(string city)
        {
            throw new NotImplementedException();
        }

        public void RemoveCitySource(string city, int source)
        {
            throw new NotImplementedException();
        }

        public void RemoveCitySource(string city, List<int> source)
        {
            throw new NotImplementedException();
        }

        public void TestFunc()
        {
            AddCity("Kyiv", "Ukraine");
        }
    }
}
