using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        readonly IMongoCarDbContext _db;
        readonly IMongoCollection<Car> _carCollection;

        public CarController(IMongoCarDbContext context)
        {
            _db = context;
            _carCollection = _db.GetCollection<Car>(typeof(Car).Name);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            var all = await _carCollection.FindAsync(c => true);
            return Ok(all.ToList());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Car>> Get(string id)
        {
            var oneCar = await _carCollection.FindAsync(c => c.Id == id).Result.FirstOrDefaultAsync();
            return Ok(oneCar);
        }

        [HttpPost]
        public async Task Post(Car carIn)
        {
            if (carIn == null)
                throw new ArgumentNullException(typeof(Car).Name + " object is null");
            await _carCollection.InsertOneAsync(carIn);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Car> Put(string id, Car carIn)
        {
            var car = _carCollection.Find<Car>(c => c.Id == id);
            if (car == null)
                return NotFound();

            _carCollection.ReplaceOne<Car>(c => c.Id == id, carIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var car = _carCollection.Find<Car>(c => c.Id == id).FirstOrDefault();
            if (car == null)
                return NotFound();

            _carCollection.DeleteOne<Car>(c => c.Id == id);
            return NoContent();
        }
    }
}
