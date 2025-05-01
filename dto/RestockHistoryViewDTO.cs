namespace GROCERYDISCOUNTBACKEND.MODELS {
    public class RestockHistoryViewDTO {
        public String? ProductName { get; set; }
        public int Amount { get; set; }
        public DateOnly? Date { get; set; }
    }
}