using MongoDB.Driver;

namespace CarAPI.Infrastructure
{
    public interface IMongoCarDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
