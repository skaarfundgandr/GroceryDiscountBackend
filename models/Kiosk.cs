using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("kiosks")]
    public class Kiosk {
        [Key]
        public long KioskID { get; set; }
        [Required]
        [StringLength(50)]
        public required string Username { get; set; }
        [Required]
        [StringLength(50)]
        public required string Password { get; set; }
        public List<SalesDetails>? SalesDetails { get; set; }
        public List<Sales>? Sales { get; set; }
        public List<Inventory>? Inventory { get; set; }
    }
}