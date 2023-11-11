using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCylcone.API.Dtos
{
    public class ColorDTO
    { 

        public int ColorId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
