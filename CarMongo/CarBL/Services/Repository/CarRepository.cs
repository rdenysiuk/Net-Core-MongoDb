using CarDL;
using CarEntities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarBL.Services.Repository
{
    class CarRepository : ICarRepository
    {
        private readonly IMongoCarDbContext _db;
        private readonly IMongoCollection<Car> _carCollection;

        public CarRepository(IMongoCarDbContext db)
        {
            _db = db;
            _carCollection = _db.GetCollection<Car>(typeof(Car).Name);
        }

        public Task<long> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<long> Edit(Car carIn)
        {
            throw new NotImplementedException();
        }

        public Task<string> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> New(Car carIn)
        {
            throw new NotImplementedException();
        }
    }
}
