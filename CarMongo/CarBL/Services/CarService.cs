using CarBL.Interfaces;
using CarBL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBL.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepo;

        public CarService(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }
        public async Task<long> Delete(string id)
        {
            return await _carRepo.Delete(id);
        }

        public async Task<long> Edit(CarModel carIn)
        {
            return await _carRepo.Edit(carIn);
        }

        public async Task<CarModel> Get(string id)
        {
            return await _carRepo.Get(id);
        }

        public async Task<List<CarModel>> GetAll()
        {
            return await _carRepo.GetAll();
        }

        public async Task<string> New(CarModel carIn)
        {
            return await _carRepo.New(carIn);
        }
    }
}
