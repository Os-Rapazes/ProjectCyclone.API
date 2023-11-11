using ProjectCylcone.API.Dtos;
using ProjectCylcone.API.Models.Entities;

namespace ProjectCylcone.API.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<List<CarDTO>> FindAllAsync();
        Task<CarDTO> FindById(Guid id);
        Task<CarDTO> Insert(CarRegisterDTO car);
        Task Update(CarDTO car);
        Task<bool> Delete(Guid id);

    }
}
