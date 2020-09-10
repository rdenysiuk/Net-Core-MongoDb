using AutoMapper;
using CarBL.Interfaces;
using CarBL.Models;
using CarBL.Services.Repository;
using CarDL;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBL.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepo;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepo, IMapper mapper)
        {
            _carRepo = carRepo;
            _mapper = mapper;
        }
        public async Task<DeleteResult> Delete(string id)
        {
            return await _carRepo.Delete(id);
        }

        public async Task<UpdateResult> Edit(CarModel carIn)
        {
            return await _carRepo.Edit(_mapper.Map<Car>(carIn));
        }

        public async Task<CarModel> Get(string id)
        {
            var car = await _carRepo.Get(id);
            return _mapper.Map<CarModel>(car);
        }

        public async Task<List<CarModel>> GetAll()
        {
            return _mapper.Map<List<Car>,List<CarModel>>( 
                await _carRepo.GetAll()
                );
        }

        public async Task<string> New(CarModel carIn)
        {
            var car = _mapper.Map<Car>(carIn);
            var id = await _carRepo.New(car);
            return id;
        }
    }
}
