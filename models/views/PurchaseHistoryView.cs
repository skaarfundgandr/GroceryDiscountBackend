using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GROCERYDISCOUNTBACKEND.MODELS.VIEWS {
    [Keyless]
    [Table("view_purchaseHistory")]
    public class PurchaseHistoryView {
        public long Kiosk { get; set; }
        [Column("Product Name")]
        public required String ProductName { get; set; }
        public int Amount { get; set; }
        [Column("Date")]
        public DateOnly Date { get; set; }
    }
}
