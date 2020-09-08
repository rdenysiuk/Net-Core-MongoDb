using CarBL.Interfaces;
using CarBL.Services.Repository;
using CarEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBL.Services
{
    class CarService : ICarService
    {
        private readonly ICarRepository _carRepo;
        public CarService(ICarRepository carRepo)
        {
            _carRepo = carRepo;
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
