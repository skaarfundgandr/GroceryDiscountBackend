using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("salesDetails")]
    public class SalesDetails {
        [Key]
        public long ReferenceID { get; set; }
        [ForeignKey("Inventory")]
        public long InventoryID { get; set; }
        [ForeignKey("Sales")]
        public long SalesID { get; set; }
        [ForeignKey("Kiosk")]
        public long KioskID { get; set; }

        public Inventory? Inventory { get; set; }
        public Sales? Sales { get; set; }
        public Kiosk? Kiosk { get; set; }
    }
}