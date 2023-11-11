using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ProjectCylcone.API.Dtos
{
    public record ClientDTO(
        Guid ClientId,
        [Required]
        string FirstName,
        [Required]
        string LastName,
        [Required]
        string Cpf,
        [Required]
        string Rg,
        bool State
        )
    {

    }
}
