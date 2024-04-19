namespace UserMicroserviceAPI.Core.Interfaces.Utility
{
    public interface IPasswordHasher
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
