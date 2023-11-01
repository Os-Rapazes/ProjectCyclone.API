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
        private readonly IColorRepository _colorRepository;

        public ColorsController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Color>>> GetColors()
        {
            var colors = await _colorRepository.FindAllColors();
            return Ok(colors);
        }


    }
}
