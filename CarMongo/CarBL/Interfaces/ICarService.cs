using CarEntities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBL.Interfaces
{
    interface ICarService
    {
        Task<List<Car>> GetAll();
        
        Task<Car> Get(string id);
        
        Task<string> New(Car carIn);
        
        Task<long> Edit(Car carIn);

        Task<DeleteResult> Delete(string id);
    }
}
