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
        // One to one
        public required Product Product { get; set; }
        public List<RestockHistory>? RestockHistory { get; set; }
        public List<Sales>? Sales { get; set; }
        public List<Kiosk>? Kiosk { get; set; }
    }
}