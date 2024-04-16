using UserMicroserviceAPI.Core.Entities.User;

namespace UserMicroserviceAPI.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> Login(string username, string password);
    }
}
