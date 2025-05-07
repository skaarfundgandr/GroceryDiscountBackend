using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GROCERYDISCOUNTBACKEND.MODELS.VIEWS {
    [Keyless]
    [Table("view_invProducts")]
    public class InventoryProductsViewModel {
        [Column("Inventory ID")]
        public long InventoryID { get; set; }
        [Column("Product Name")]
        public required String ProductName { get; set; }
        public String? Description { get; set; }
        public required String Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public String? Units { get; set; }
        [Column("Last Restock")]
        public DateOnly? LastRestock { get; set; }
    }
}