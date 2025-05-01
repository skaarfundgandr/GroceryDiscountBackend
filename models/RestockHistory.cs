using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("restockHistory")]
    public class RestockHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int restockID { get; set; }
        [Required]
        [ForeignKey("Inventory")]
        public long inventoryID { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public required DateOnly date { get; set; }

        public required Inventory Inventory { get; set; }
    }
}