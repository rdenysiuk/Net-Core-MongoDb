using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarDL.DBContext
{
    public class MongoCarDbContext : IMongoCarDbContext
    {
        readonly IMongoDatabase _db;

        public MongoCarDbContext(IOptions<MongoSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.Connection);
            _db = mongoClient.GetDatabase(options.Value.DatabaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
