using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ProjectCylcone.API.Dtos;
using ProjectCylcone.API.Repository.Interfaces;

namespace ProjectCylcone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient(ClientRegisterDTO dto)
        {
            await clientRepository.Insert(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<ClientDTO>>> GetClients()
        {
            return Ok(await clientRepository.FindAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(Guid id)
        {
            return Ok(await clientRepository.FindById(id));
        }

        [HttpPut]
        public async Task<ActionResult<ClientDTO>> PutClient(ClientDTO dto)
        {
            ClientDTO verify = await clientRepository.FindById(dto.ClientId);

            if (verify.Equals(null)) return NotFound($"Client not found with id : {dto.ClientId}");

            await clientRepository.Update(dto);

            return Ok(dto);
        }

        [HttpPatch("DeactiveClient/{id}")]
        public async Task<ActionResult> DeactiveClient(Guid id) {

           bool confirm =  await clientRepository.DeactiveClient(id);

            if (!confirm) return BadRequest("Client not found");

           return NoContent();
        }

        [HttpPatch("ActiveClient/{id}")]
        public async Task<ActionResult> ActiveClient(Guid id) {

            await clientRepository.ActiveClient(id);

            return NoContent();
        }
    }
}
