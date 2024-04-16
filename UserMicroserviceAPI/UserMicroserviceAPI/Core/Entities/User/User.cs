namespace UserMicroserviceAPI.Core.Entities.User
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Rol { get; set; }
        public byte[] PasswordHash { get; set; }  
        public byte[] PasswordSalt { get; set; }
    }
}
