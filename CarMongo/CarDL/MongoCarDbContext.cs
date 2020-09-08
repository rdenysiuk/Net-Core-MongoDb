using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarDL
{
    public class MongoCarDbContext : IMongoCarDbContext
    {
        IMongoDatabase _db;
        IMongoClient _mongoClient;

        public MongoCarDbContext(IOptions<MongoSettings> options)
        {
            _mongoClient = new MongoClient(options.Value.Connection);
            _db = _mongoClient.GetDatabase(options.Value.DatabaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
