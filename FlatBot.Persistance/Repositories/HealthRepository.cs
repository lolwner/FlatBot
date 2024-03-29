﻿using FlatBot.Application.Persistance;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlatBot.Persistance.Repositories
{
    public class HealthRepository : IHealthRepository
    {
        private readonly IMongoDatabase _database;

        public HealthRepository(IOptions<MongoDbSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            _database = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DBName);

            if (!_database.ListCollections().Any())
            {
                _database.CreateCollection(bookStoreDatabaseSettings.Value.Collection);
            }

        }

        public async Task<bool> CheckHealthAsync()
        {
            try
            {
                var pingResult = await _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}");

                return pingResult.Names.Contains("ok");
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
    }
}
