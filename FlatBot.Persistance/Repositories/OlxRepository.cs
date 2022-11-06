using FlatBot.Application.Persistance;
using FlatBot.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlatBot.Persistance.Repositories
{
    internal class OlxRepository : IOlxRepository
    {
        private readonly IMongoCollection<OlxOfferEntity> _booksCollection;

        public OlxRepository(
            IOptions<MongoDbSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DBName);

            _booksCollection = mongoDatabase.GetCollection<OlxOfferEntity>(
                bookStoreDatabaseSettings.Value.Collection);
        }

        public async Task<List<OlxOfferEntity>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<OlxOfferEntity> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(OlxOfferEntity newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task CreateAsync(List<OlxOfferEntity> newBooks) =>
            await _booksCollection.InsertManyAsync(newBooks);

        public async Task UpdateAsync(string id, OlxOfferEntity updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
