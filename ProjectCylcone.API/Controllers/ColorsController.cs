using Microsoft.AspNetCore.Mvc;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Models.Entities;
using ProjectCylcone.API.Repository.Interfaces;

namespace ProjectCylcone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICarRepository _carRepository;

        //ID - Injeção de Dependência
        public ColorsController(AppDbContext context, ICarRepository carRepository)
        {
            _context = context;
            _carRepository = carRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {

            _context.Colors.Add(color);
            
            await _context.SaveChangesAsync(); 

            return Ok(color);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCarsWithColorRed()
        {
           var cars = await _carRepository.FindAllAsync();
   
            return Ok(cars);
        }

    }
}
