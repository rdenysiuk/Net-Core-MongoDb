using CarBL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBL.Interfaces
{
    public interface ICarRepository
    {
        Task<List<CarModel>> GetAll();

        Task<CarModel> Get(string id);

        Task<string> New(CarModel carIn);

        Task<long> Edit(CarModel carIn);

        Task<long> Delete(string id);
    }
}
