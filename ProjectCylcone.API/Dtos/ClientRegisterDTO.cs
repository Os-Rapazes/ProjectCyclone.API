using System.ComponentModel.DataAnnotations;

namespace ProjectCylcone.API.Dtos
{
    public record ClientRegisterDTO(
            [Required]
            string FirstName,
            [Required]
            string LastName,
            [Required]
            [StringLength(maximumLength: 11,MinimumLength = 11, ErrorMessage = "Cpf field must have 11 charachtares")]
            string Cpf,
            [Required]
            [StringLength(maximumLength: 9,MinimumLength = 9, ErrorMessage = "Rg field must have 9 charachtares")]
            string Rg
        )
    {
    }
}
