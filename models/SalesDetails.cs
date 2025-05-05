using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("salesDetails")]
    public class SalesDetails {
        [Key]
        public long ReferenceID { get; set; }
        public long InventoryID { get; set; }
        public long SalesID { get; set; }
        public long KioskID { get; set; }
        // Many to many
        [ForeignKey(nameof(InventoryID))]
        public List<Inventory>? Inventory { get; set; }
        [ForeignKey(nameof(SalesID))]
        public List<Sales>? Sales { get; set; }
        [ForeignKey(nameof(KioskID))]
        public List<Kiosk>? Kiosk { get; set; }
    }
}