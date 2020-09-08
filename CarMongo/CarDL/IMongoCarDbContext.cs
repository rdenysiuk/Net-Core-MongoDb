using MongoDB.Driver;

namespace CarDL
{
    public interface IMongoCarDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
