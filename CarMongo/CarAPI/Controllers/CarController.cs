using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            await _carService.New(carIn);
            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] CarModel carIn)
        {
            var updateCount = await _carService.Edit(carIn);
            if (updateCount > 0)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteCount = await _carService.Delete(id);
            if (deleteCount > 0)
                return Ok();

            return NoContent();
        }
    }
}
