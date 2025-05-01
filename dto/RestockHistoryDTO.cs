namespace GROCERYDISCOUNTBACKEND.DTO {
    public class RestockHistoryDTO {
        public int Amount { get; set; }
        public DateOnly Date { get; set; }
        public InventoryDTO? Inventory { get; set; }
    }
}