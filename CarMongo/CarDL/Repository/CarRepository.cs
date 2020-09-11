using CarDL.DBContext;
using CarDL.Entities;
using CarBL.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarBL.Models;
using AutoMapper;

namespace CarDL.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoCarDbContext _db;
        private readonly IMongoCollection<Car> _carCollection;
        private readonly IMapper _mapper;

        public CarRepository(IMongoCarDbContext db, IMapper mapper)
        {
            _db = db;
            _carCollection = _db.GetCollection<Car>(typeof(Car).Name);
            _mapper = mapper;
        }

        /// <summary>
        /// Delete car
        /// </summary>
        /// <param name="id">acr id</param>
        /// <returns>return count of deleted records</returns>
        public async Task<long> Delete(string id)
        {
            try
            {
                var deleteResult = await _carCollection.DeleteOneAsync(c => c.Id == id);
                return deleteResult.DeletedCount;
            }
            catch (Exception deleteException)
            {

                throw new ApplicationException(deleteException.Message, deleteException);
            }
        }

        /// <summary>
        /// Edit car
        /// </summary>
        /// <param name="carIn">car object</param>
        /// <returns>return changes count</returns>
        public async Task<long> Edit(CarModel carIn)
        {
            try
            {
                var filter = Builders<Car>.Filter.Eq(c => c.Id, carIn.Id);
                var update = Builders<Car>.Update.Set(c => c.Name, carIn.Name)
                        .Set(d=>d.Description, carIn.Description);
                
                var updateResult = await _carCollection.UpdateOneAsync(filter, update);
                return updateResult.ModifiedCount;
            }
            catch (Exception editException)
            {

                throw new ApplicationException(editException.Message, editException);
            }
        }

        public async Task<CarModel> Get(string id)
        {
            try
            {
                return _mapper.Map<CarModel>(
                    await _carCollection.FindAsync(c => c.Id == id).Result.FirstOrDefaultAsync()
                    );
            }
            catch (Exception getException)
            {

                throw new ApplicationException(getException.Message, getException);
            }
        }

        public async Task<List<CarModel>> GetAll()
        {
            try
            {
                var carList = await _carCollection.FindAsync(c => true);
                return _mapper.Map<List<Car>, List<CarModel>>(carList.ToList());
            }
            catch (Exception getAllException)
            {
                throw new ApplicationException(getAllException.Message, getAllException);
            }
        }

        public async Task<string> New(CarModel carIn)
        {
            if (carIn == null)
                throw new ArgumentNullException(typeof(CarModel).Name + " object is null");
            try
            {
                var car = _mapper.Map<Car>(carIn);
                await _carCollection.InsertOneAsync(car);
                return car.Id;
            }
            catch (Exception newException)
            {
                throw new ApplicationException(newException.Message, newException);
            }
        }

    }
}
