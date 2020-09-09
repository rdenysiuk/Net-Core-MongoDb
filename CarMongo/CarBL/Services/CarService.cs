using CarBL.Interfaces;
using CarBL.Services.Repository;
using CarEntities;
using MongoDB.Driver;
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
        public Task<DeleteResult> Delete(string id)
        {
            return _carRepo.Delete(id);
        }

        public async Task<long> Edit(Car carIn)
        {
            return await _carRepo.Edit(carIn);
        }

        public async Task<Car> Get(string id)
        {
            return await _carRepo.Get(id);
        }

        public async Task<List<Car>> GetAll()
        {
            return await _carRepo.GetAll();
        }

        public async Task<string> New(Car carIn)
        {
            return await _carRepo.New(carIn);
        }
    }
}
