namespace UserMicroserviceAPI.Core.Entities.Users
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }  
        public byte[] PasswordSalt { get; set; }
    }
}
