using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Dtos;
using ProjectCylcone.API.Models.Entities;
using ProjectCylcone.API.Repository.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace ProjectCylcone.API.Repository.Classes
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;
        
        private readonly IMapper _mapper;


        public ClientRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClientDTO>> FindAllAsync()
        {
            var clients = _mapper.Map<List<ClientDTO>>
                (await _context.Clients.ToListAsync());
            return clients;
        }

        public async Task<ClientDTO> FindById(Guid id)
        {
            return _mapper.Map<ClientDTO>(await _context.Clients
                .AsNoTracking().FirstOrDefaultAsync(x => x.ClientId.Equals(id)));

        }

        public async Task Insert(ClientRegisterDTO dto)
        {
            var client = _mapper.Map<Client>(dto);

            _context.Add(client);

            await _context.SaveChangesAsync();
        }

        public async Task Update(ClientDTO dto)
        {
            Client client = _mapper.Map<Client>(dto);
            
            _context.Update(client);
            
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeactiveClient(Guid id)
        {
            Client client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId.Equals(id));
            
            if (client == null) return false;

            client.State = false;

            //Remove os carros que estão associados ao cliente desativado
            _context.Cars.RemoveRange(_context.Cars.Where(car => car.ClientId.Equals(id)));
           
            await _context.SaveChangesAsync();
            
            return true;

        }

        public async Task<bool> ActiveClient(Guid id)
        {

            Client client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId.Equals(id));

            if (client == null) return false;

            client.State = true;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
