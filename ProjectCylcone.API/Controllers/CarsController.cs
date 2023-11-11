using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Dtos;
using ProjectCylcone.API.Models.Entities;
using ProjectCylcone.API.Repository.Classes;
using ProjectCylcone.API.Repository.Interfaces;

namespace ProjectCylcone.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ICarRepository _carRepository;

        //Injeção de Depência
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<CarDTO>>> GetCars()
        {
            List<CarDTO> cars = await _carRepository.FindAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(Guid id)
        {
            CarDTO car = await _carRepository.FindById(id);

            if (car.Equals(null))
                return BadRequest("Car not found");

            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> PostCar(CarRegisterDTO dto)
        {
            CarDTO car =  await _carRepository.Insert(dto);

            return Created($"/api/cars/{car.CarId}", car);
        }

        [HttpPut]
        public async Task<ActionResult<Car>> PutCar(CarDTO dto)
        {
            //Programação defensiva
            CarDTO carVerify = await _carRepository.FindById(dto.CarId);

            if (carVerify.Equals(null))
                return BadRequest("Car not found");

            await _carRepository.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            bool verifyDelet = await _carRepository.Delete(id);

            if (!verifyDelet) return BadRequest("Car not found");

            return NoContent();
        }
    }
}
