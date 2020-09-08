using CarEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarBL.Services.Repository
{
    interface ICarRepository
    {
        Task<List<Car>> GetAll();

        Task<string> Get(string id);

        Task<string> New(Car carIn);

        Task<long> Edit(Car carIn);

        Task<long> Delete(string id);
    }
}
