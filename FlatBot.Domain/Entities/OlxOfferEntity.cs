using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlatBot.Domain.Entities
{
    public class OlxOfferEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime UTCDate { get; set; }
        public DateTime CreattionDateUTC { get; set; }
        public string BatchId { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }

        //public string Currency { get; set; }
    }
}
