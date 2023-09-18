using Microsoft.EntityFrameworkCore;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Models.Entities;
using ProjectCylcone.API.Repository.Interfaces;
using System.Net;

namespace ProjectCylcone.API.Repository.Classes
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<Car>> FindAllAsync()
        {
            List<Car> cars = await _context.Cars.ToListAsync();

            return cars;
        }

        public async Task<Car> FindById(Guid id)
        {
            Car car = await _context.Cars.FirstOrDefaultAsync(c => c.CarId.Equals(id));
            return car;
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


        public async Task Insert(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public void Update(Car car)
        {
           
        }
        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }

    }
}
