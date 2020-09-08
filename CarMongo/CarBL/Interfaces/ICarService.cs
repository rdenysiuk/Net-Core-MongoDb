using CarEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBL.Interfaces
{
    interface ICarService
    {
        Task<List<Car>> GetAll();
        
        Task<string> Get(string id);
        
        Task<string> New(Car carIn);
        
        Task<long> Edit(Car carIn);

        Task<long> Delete(string id);
    }
}
