using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAPI.Entities;
using CarAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        IMongoCarDbContext _db;
        IMongoCollection<Car> _carCollection;

        public CarController(IMongoCarDbContext context)
        {
            _db = context;
            _carCollection = _db.GetCollection<Car>(typeof(Car).Name);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            var all = await _carCollection.FindAsync(Builders<Car>.Filter.Empty);
            return Ok(all.ToList());
        }

        [HttpPost]
        public ActionResult<Car> Post(Car carIn)
        {
            throw NotImplementedException();
        }
    }
}
