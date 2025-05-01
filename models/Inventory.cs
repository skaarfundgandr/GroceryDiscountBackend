using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("inventory")]
    public class Inventory {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InventoryID { get; set; }
        [ForeignKey("Product")]
        [Required]
        public long ProductID { get; set; }
        [StringLength(50)]
        public string? Units { get; set; }
        [Required]
        public int Quantity { get; set;}
        public DateOnly? LatestRestock { get; set; }
        // Required to model relations
        public required Product Product { get; set; }
    }
}