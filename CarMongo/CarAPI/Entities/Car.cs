using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CarAPI.Entities
{
    public class Car
    {
        [BsonId]        
        public Guid Id { get; set; }
        [BsonRequired]
        public string Name { get; set; }
        public string Description { get; set; }
        [BsonRequired]
        public decimal Price { get; set; }
    }
}
