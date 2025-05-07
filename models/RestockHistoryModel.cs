using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("restockHistory")]
    public class RestockHistoryModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestockID { get; set; }
        [Required]
        public long InventoryID { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public required DateOnly Date { get; set; }
        // One restock could have many inventory items
        [ForeignKey(nameof(InventoryID))]
        public required InventoryModel Inventory { get; set; }
    }
}