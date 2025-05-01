namespace GROCERYDISCOUNTBACKEND.DTO {
    public class PurchaseHistoryViewDTO {
        public long KioskID { get; set; }
        public String? ProductName { get; set; }
        public int Amount { get; set; } 
        public DateOnly Date { get; set; }
    }
}