using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CarDL.Entities
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required()]
        public string Id { get; set; }

        [BsonRequired]
        [Required()]
        public string Name { get; set; }

        public string Description { get; set; }

        [BsonRequired]
        [Required()]
        public decimal Price { get; set; }

        public Car(string id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
