using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using CarBL.Interfaces;
using CarBL.Models;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            this._carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModel>>> Get()
        {
            return Ok(await _carService.GetAll());
        }

        [HttpGet("{id:length(24)}", Name = "CarGet")]
        public async Task<ActionResult<CarModel>> Get(string id)
        {

            var oneCar = await _carService.Get(id);
            if (oneCar != null)
                return Ok(oneCar);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CarModel carIn)
        {
            if (carIn == null)
                throw new ArgumentNullException(typeof(CarModel).Name + " object is null");
            var carId = await _carService.New(carIn);
            return CreatedAtRoute("CarGet", new { id = carId });
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> Put(string id, [FromBody] CarModel carIn)
        {
            UpdateResult result = await _carService.Edit(carIn);
            if (result.IsAcknowledged)
                return CreatedAtRoute("CarGet", new { id = carIn.Id });
            else
                return NotFound();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteResult = await _carService.Delete(id);
            if (deleteResult.IsAcknowledged)
                return NoContent();

            return NoContent();
        }
    }
}
