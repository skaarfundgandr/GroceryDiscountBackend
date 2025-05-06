namespace GROCERYDISCOUNTBACKEND.DTO {
    public class ProductDTO {
        public String ProductName {get; set;} = null!;
        public String? ProductDesc {get; set;}
        public String ProductCategory {get; set;} = null!;
        public decimal ProductPrice {get; set;}
    }
}