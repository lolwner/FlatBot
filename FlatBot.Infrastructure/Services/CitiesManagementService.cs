using FlatBot.Application.Services;
using FlatBot.Infrastructure.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace FlatBot.Infrastructure.Services
{
    public class CitiesManagementService : ICitiesManagementService
    {
        public CitiesManagementService()
        {
        }

        public void AddCitiesToSource(int source, List<string> cities)
        {
            throw new NotImplementedException();
        }

        public void AddSourceToCity(string city, int source)
        {
            throw new NotImplementedException();
        }

        public void AddSourceToCity(string city, List<int> source)
        {
            throw new NotImplementedException();
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
            var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures).ToList();
            var cities = GetCities();
        }

        private List<CityViewModel> GetCities()
        {
            using (StreamReader r = new StreamReader("Resources/cities.json"))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<CityViewModel>>(json);
                return items;
            }
        }
    }
}
