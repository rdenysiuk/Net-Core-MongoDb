using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarEntities
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public string Description { get; set; }

        [BsonRequired]
        public decimal Price { get; set; }
    }
}
