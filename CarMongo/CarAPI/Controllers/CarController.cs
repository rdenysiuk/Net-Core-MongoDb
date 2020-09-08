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

        [HttpGet("{id:length(24)}", Name ="CarGet")]
        public async Task<ActionResult<Car>> Get(string id)
        {
            var oneCar = await _carCollection.FindAsync(c => c.Id == id).Result.FirstOrDefaultAsync();
            if (oneCar != null)
                return Ok(oneCar);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Car carIn)
        {
            if (carIn == null)
                throw new ArgumentNullException(typeof(Car).Name + " object is null");
            await _carCollection.InsertOneAsync(carIn);
            return CreatedAtRoute("CarGet", new {id  = carIn.Id});
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> Put(string id,[FromBody] Car carIn)
        {
            /*
            var car = _carCollection.FindAsync(c => c.Id == id).Result.FirstOrDefaultAsync();
            if (car == null)
                return NotFound();*/
            var filter = Builders<Car>.Filter.Eq(c => c.Id, id);
            var update = Builders<Car>.Update.Set(u => u.Description, carIn.Description);
           UpdateResult result  = await _carCollection.UpdateOneAsync(filter, update);
            //CreatedAtRoute();
            if (result.ModifiedCount > 0)
                return CreatedAtRoute("CarGet", new { id = carIn.Id });
            else
                return NotFound();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var car = _carCollection.Find<Car>(c => c.Id == id).FirstOrDefault();
            if (car == null)
                return NotFound();

            var result = await _carCollection.DeleteOneAsync(c => c.Id == id);
            return NoContent();
        }
    }
}
