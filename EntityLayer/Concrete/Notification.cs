namespace EntityLayer.Concrete
{
    public class Notification
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string TypeSymbol { get; set; }
        public string Details { get; set; }
        public bool Status { get; set; }
        public DateTime? Date { get; set; }
        public string Color { get; set; }
    }
}
