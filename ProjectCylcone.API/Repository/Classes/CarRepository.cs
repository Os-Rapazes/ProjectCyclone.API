using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Dtos;
using ProjectCylcone.API.Models.Entities;
using ProjectCylcone.API.Repository.Interfaces;
using System.Net;

namespace ProjectCylcone.API.Repository.Classes
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CarRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CarDTO>> FindAllAsync()
        {
            List<CarDTO> cars = _mapper.Map<List<CarDTO>>(
                await _context.Cars.AsNoTracking()
                .Include(c => c.Color)
                .Include(c => c.Client)
                .ToListAsync());

            return cars;
        }

        public async Task<CarDTO> FindById(Guid id)
        {
            CarDTO car = _mapper.Map<CarDTO>(
            
                await _context.Cars
                .AsNoTracking()
                .Include(c => c.Color)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(c => c.CarId.Equals(id)));

            return car;
        }

        public async Task<CarDTO> Insert(CarRegisterDTO dto)
        {
            Car car = _mapper.Map<Car>(dto);
            
            _context.Cars.Add(car);
            
            await _context.SaveChangesAsync();

            return _mapper.Map<CarDTO>(car);
       }

        public async Task Update(CarDTO dto)
        {
            Car car = _mapper.Map<Car>(dto);
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            Car car = await _context.Cars.FirstOrDefaultAsync(car => car.CarId.Equals(id));

            if (car == null)
                return false;
            _context.Cars.Remove(car);
            
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
