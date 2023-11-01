using System.ComponentModel.DataAnnotations;

namespace ProjectCylcone.API.Models.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        [StringLength(9)]
        [Required]
        public string Rg { get; set; }
        public bool State { get; set; } = true;

    }
}
