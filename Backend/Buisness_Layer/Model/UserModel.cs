namespace Buisness_Layer.Model
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
    }
}
