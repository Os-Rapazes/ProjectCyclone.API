using Microsoft.EntityFrameworkCore;
using ProjectCylcone.API.Models.Entities;

namespace ProjectCylcone.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Client> Clients { get; set; }


    }
}
