using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlatBot.Domain.Entities
{
    public class Country
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CountryName { get; set; }
    }
}
