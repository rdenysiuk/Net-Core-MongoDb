using CarEntities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarBL.Services.Repository
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAll();

        Task<Car> Get(string id);

        Task<string> New(Car carIn);

        Task<UpdateResult> Edit(Car carIn);

        Task<DeleteResult> Delete(string id);
    }
}
