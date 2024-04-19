using UserMicroserviceAPI.Core.Entities.Users;

namespace UserMicroserviceAPI.Core.Interfaces.Account.Login
{
    public interface ILoginRepository
    {
        Task<Users> Login(string email);
    }
}
