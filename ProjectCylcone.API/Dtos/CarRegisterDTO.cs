using ProjectCylcone.API.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectCylcone.API.Dtos
{
    public record CarRegisterDTO(
        [Required]
        string Plate,
        [Required]
        int ColorId,
        [Required]
        string Model,
        [Required]
        string Brand,
        [Required]
        double Price,
        [Required]
        string ClientId
        )
    {
    }
}
