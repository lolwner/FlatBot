using FlatBot.Application.Persistance;
using FlatBot.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlatBot.Persistance.Repositories
{
    public class CitiesManagementRepository : ICitiesManagementRepository
    {
        private readonly IMongoCollection<CitySource> _cityCollection;

        public CitiesManagementRepository(IOptions<MongoDbSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DBName);

            _cityCollection = mongoDatabase.GetCollection<CitySource>(
                bookStoreDatabaseSettings.Value.Collection);
        }

        public Task AddCity(string city)
        {
            return _cityCollection.InsertOneAsync(new CitySource
            {
                City = city
            });
        }

        public void AddSourceToCity(string city, int source)
        {
            var update = Builders<CitySource>.Update
                .Set(m => m.Sources[-1], source);

            _cityCollection.FindOneAndUpdate(x => string.Equals(city, x.City), update);
        }
    }
}
