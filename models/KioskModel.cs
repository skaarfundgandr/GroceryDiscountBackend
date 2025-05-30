using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("kiosks")]
    public class KioskModel {
        [Key]
        public long KioskID { get; set; }
        [Required]
        [StringLength(50)]
        public required string Username { get; set; }
        [Required]
        [StringLength(50)]
        public required string Password { get; set; }
        public List<SalesDetailsModel>? SalesDetails { get; set; }
    }
}