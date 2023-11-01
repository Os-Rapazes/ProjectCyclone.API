using ProjectCylcone.API.Dtos;
using ProjectCylcone.API.Models.Entities;

namespace ProjectCylcone.API.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientDTO>> FindAllAsync();
        Task<ClientDTO> FindById(Guid id);
        Task Insert(ClientRegisterDTO dto);
        Task Update(ClientDTO dto);
        Task<bool> DeactiveClient(Guid id);
        Task<bool> ActiveClient(Guid id);

    }
}
