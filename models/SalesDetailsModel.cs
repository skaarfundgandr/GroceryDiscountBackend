using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("salesDetails")]
    public class SalesDetailsModel {
        [Key]
        public long ReferenceID { get; set; }
        public long InventoryID { get; set; }
        public long SalesID { get; set; }
        public long KioskID { get; set; }
        // Many to many
        [ForeignKey(nameof(InventoryID))]
        public List<InventoryModel>? Inventory { get; set; }
        [ForeignKey(nameof(SalesID))]
        public List<SalesModel>? Sales { get; set; }
        [ForeignKey(nameof(KioskID))]
        public List<KioskModel>? Kiosk { get; set; }
    }
}