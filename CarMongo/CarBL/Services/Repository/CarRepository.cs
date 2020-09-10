using CarDL;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBL.Services.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoCarDbContext _db;
        private readonly IMongoCollection<Car> _carCollection;

        public CarRepository(IMongoCarDbContext db)
        {
            _db = db;
            _carCollection = _db.GetCollection<Car>(typeof(Car).Name);
        }

        public async Task<DeleteResult> Delete(string id)
        {
            try
            {
                return await _carCollection.DeleteOneAsync(c => c.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UpdateResult> Edit(Car carIn)
        {
            try
            {
                var filter = Builders<Car>.Filter.Eq(c => c.Id, carIn.Id);
                var update = Builders<Car>.Update.Set(c => c.Name, carIn.Name);
                return await _carCollection.UpdateOneAsync(filter, update);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Car> Get(string id)
        {
            try
            {
               return await _carCollection.FindAsync(c => c.Id == id).Result.FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Car>> GetAll()
        {
            try
            {
                var carList = await _carCollection.FindAsync(c => true);
                return carList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> New(Car carIn)
        {
            try
            {
                await _carCollection.InsertOneAsync(carIn);
                return carIn.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
