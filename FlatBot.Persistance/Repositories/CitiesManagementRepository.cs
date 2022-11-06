using FlatBot.Application.Persistance;
using FlatBot.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System.Numerics;

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

        public async Task AddCity(CitySource city)
        {
            try
            {
                await _cityCollection.InsertOneAsync(city);
            }
            catch (Exception)
            {

            }
        }

        public void AddSourceToCity(string city, int source)
        {
            var update = Builders<CitySource>.Update
                .Set(m => m.Sources[-1], source);

            _cityCollection.FindOneAndUpdate(x => string.Equals(city, x.CityName), update);
        }

        public async Task AddCitiesToSourceAsync(int source, List<string> cityIds)
        {
            var citiess = await _cityCollection.Find(x => cityIds.Contains(x.CityId)).ToListAsync();

            citiess.ForEach(x => x.Sources.Add(source));
            UpdateDefinition<CitySource> updateDefinition = Builders<CitySource>.Update.Set(x => x.Sources[-1], source);
            _cityCollection.UpdateMany(x => cityIds.Contains(x.CityId), updateDefinition);
        }
    }
}
