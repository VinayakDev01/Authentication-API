namespace AuthenticationAPI.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<string> Regions { get; set; }
    }
}
