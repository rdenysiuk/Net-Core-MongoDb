using CarBL.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBL.Interfaces
{
    public interface ICarService
    {
        Task<List<CarModel>> GetAll();
        
        Task<CarModel> Get(string id);
        
        Task<string> New(CarModel carIn);
        
        Task<UpdateResult> Edit(CarModel carIn);

        Task<DeleteResult> Delete(string id);
    }
}
