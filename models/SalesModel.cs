using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GROCERYDISCOUNTBACKEND.MODELS {
    [Table("sales")]
    public class SalesModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SalesID { get; set; }
        [Required]
        public required int Amount { get; set; }
        [Required]
        public required DateOnly Date { get; set; }

        public List<SalesDetailsModel>? SalesDetails { get; set; }
    }
}