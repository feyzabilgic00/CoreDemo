namespace CoreDemo.Models
{
    //IFormFile : Dosyadan veri seçebilmek yada bir dosyadan bir dosya değeri 
    //seçebilmek için IFormFile kullanıyoruz.
    public class AddProfileImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public IFormFile? Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
