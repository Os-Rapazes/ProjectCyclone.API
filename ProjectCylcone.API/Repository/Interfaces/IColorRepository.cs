using ProjectCylcone.API.Models.Entities;

namespace ProjectCylcone.API.Repository.Interfaces
{
    public interface IColorRepository
    {
        Task<List<Color>> FindAllColors();
    }
}
