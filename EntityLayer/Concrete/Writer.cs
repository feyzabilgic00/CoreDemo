using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Message> WriterSender { get; set; }
        public virtual ICollection<Message> WriterReceiver { get; set; }
    }
}
