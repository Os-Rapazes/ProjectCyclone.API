using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectCylcone.API.Models.Entities
{
    [Table("cars")]
    public class Car
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("car_id")]
        public Guid CarId { get; set; }

        [Column("plate")]
        [StringLength(50)]
        public string Plate { get; set; }
        
        [Column("color_id")]
        public int ColorId { get; set; }
        
        //propriedade de navegação
        public Color Color { get; set; }
        
        [Column("model")]
        [StringLength(50)]
        public string Model { get; set; }

        [Column("brand")]
        [StringLength(50)]
        public string Brand { get; set; }
        
        [Column("price")]
        public double Price { get; set; }
        [Required]

        [Column("client_id")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}
