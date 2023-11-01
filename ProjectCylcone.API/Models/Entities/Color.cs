using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCylcone.API.Models.Entities
{
    [Table("colors")]
    public class Color
    {
        [Key]
        [Column("color_id")]
        public int ColorId { get; set; }
        
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
                
    }
}
