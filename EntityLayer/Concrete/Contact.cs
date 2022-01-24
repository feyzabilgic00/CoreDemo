using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime? ContactDate { get; set; }
        public bool Status { get; set; }
    }
}
