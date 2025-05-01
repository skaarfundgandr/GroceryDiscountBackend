namespace GROCERYDISCOUNTBACKEND.DTO {
    public class InventoryProductsViewDTO {
        public String? ProductName { get; set; }
        public String? Description { get; set; }
        public String? Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public String? Units { get; set; }
        public DateOnly? LastRestock { get; set; }
    }
}