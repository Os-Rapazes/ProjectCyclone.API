using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Models.Entities;
using ProjectCylcone.API.Repository.Classes;
using ProjectCylcone.API.Repository.Interfaces;

namespace ProjectCylcone.API.Controllers
{


[Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly ICarRepository _carRepository;

        //Injeção de Depência
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


    [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            List<Car> cars = await _carRepository.FindAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(Guid id)
        {
            Car car = await _carRepository.FindById(id);

            if (car == null)
                return BadRequest("Car not found");

            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            await _carRepository.Insert(car);

            return car;
        }

        [HttpPut]
        public async Task<ActionResult<Car>> PutCar(Car car)
        {
            //Programação defensiva
            Car carVerify = await _context.Cars.FirstOrDefaultAsync(x => x.CarId.Equals(car.CarId));

            if (carVerify == null)
                return BadRequest("Car not found");

            _context.Cars.Update(car);

            await _context.SaveChangesAsync();

            return Ok(car);
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
