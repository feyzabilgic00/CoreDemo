﻿using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; }
        public string Image { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public int WriterId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Writer Writer { get; set; }
        public virtual ICollection<Comment> Comments { get; set;}
    }
}
