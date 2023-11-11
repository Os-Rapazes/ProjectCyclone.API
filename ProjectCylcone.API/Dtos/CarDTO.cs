using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCylcone.API.Models.Entities;

namespace ProjectCylcone.API.Dtos
{
    public record CarDTO(
        Guid CarId,
        [Required]
        string Plate,
        [Required]
        int ColorId,
        ColorDTO Color,
        [Required]
        string Model,
        [Required]
        string Brand,
        [Required]
        double Price,
        [Required]
        string ClientId,
        Client Client
        )
    {

    }
}
