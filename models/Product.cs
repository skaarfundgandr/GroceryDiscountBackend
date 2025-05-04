using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("products")]
    public class Product {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public required String ProductName { get; set; }
        [StringLength(50)]
        public String? ProductDesc { get; set; }
        [Required]
        [StringLength(50)]
        public required String ProductCategory { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public Inventory? Inventory { get; set; }
    }
}