namespace EntityLayer.Concrete
{
    public class BlogRating
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int TotalScore { get; set; }
        public int RatingCount { get; set; }
    }
}
