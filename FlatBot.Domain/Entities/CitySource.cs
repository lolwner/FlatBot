﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlatBot.Domain.Entities
{
    public class CitySource
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public List<int> Sources { get; set; }
    }
}
