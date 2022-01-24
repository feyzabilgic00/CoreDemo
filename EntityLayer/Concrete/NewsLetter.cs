using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class NewsLetter
    {
        [Key]
        public int Id { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
    }
}
