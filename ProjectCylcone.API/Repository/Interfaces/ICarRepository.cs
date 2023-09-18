using ProjectCylcone.API.Models.Entities;

namespace ProjectCylcone.API.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> FindAllAsync();
        Task<Car> FindById(Guid id);
        Task Insert(Car car);
        void Update(Car car);
        Task<bool> Delete(Guid id);
        Task Commit();

    }
}
