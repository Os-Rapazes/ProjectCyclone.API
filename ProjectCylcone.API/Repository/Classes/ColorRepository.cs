using Microsoft.EntityFrameworkCore;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Models.Entities;
using ProjectCylcone.API.Repository.Interfaces;

namespace ProjectCylcone.API.Repository.Classes
{
    public class ColorRepository : IColorRepository
    {
        private readonly AppDbContext _context;

        public ColorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Color>> FindAllColors()
        {
            return await _context.Colors.ToListAsync();
        }
    }
}
