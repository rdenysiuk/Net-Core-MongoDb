using CarAPI.Entities;
using CarAPI.Infrastructure;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
namespace CarAPI.DbContext
{
    public class MongoCarDbContext : IMongoCarDbContext
    {
        readonly IMongoDatabase _db;
        MongoClient _mongoClient;
        public MongoCarDbContext(IOptions<MongoSettings> configurations)
        {
            _mongoClient = new MongoClient(configurations.Value.Connection);
            _db = _mongoClient.GetDatabase(configurations.Value.DatabaseName);
        }
        public IMongoCollection<Car> GetCollection<Car>(string name)
        {
            return _db.GetCollection<Car>(name);
        }
    }
}
