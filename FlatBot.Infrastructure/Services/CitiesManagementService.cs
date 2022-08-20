using FlatBot.Application.Services;

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

        public void AddCity(string city)
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
    }
}
