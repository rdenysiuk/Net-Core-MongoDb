using MongoDB.Driver;

namespace CarDL.DBContext
{
    public interface IMongoCarDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
