namespace GROCERYDISCOUNTBACKEND.DTO {
    public class InventoryDTO {
        public String? Units { get; set; }
        public int Quantity { get; set; }
        public DateOnly LatestRestock { get; set; }
        public ProductDTO? Product { get; set; } 
    }
}