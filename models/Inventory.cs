using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("inventory")]
    public class Inventory {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InventoryID { get; set; }
        [Required]
        public long ProductID { get; set; }
        [StringLength(50)]
        public string? Units { get; set; }
        [Required]
        public int Quantity { get; set;}
        public DateOnly? LatestRestock { get; set; }
        // One to one
        [ForeignKey(nameof(ProductID))]
        public required Product Product { get; set; }
        // Many to many using join table
        public List<SalesDetails>? SalesDetails { get; set; }
    }
}