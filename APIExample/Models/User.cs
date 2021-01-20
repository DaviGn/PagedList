namespace APIExample.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}