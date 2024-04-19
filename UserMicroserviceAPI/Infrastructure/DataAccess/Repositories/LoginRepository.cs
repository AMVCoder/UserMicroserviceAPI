using Microsoft.EntityFrameworkCore;
using System;
using UserMicroserviceAPI.Core.Entities.Users;
using UserMicroserviceAPI.Core.Interfaces.Account.Login;
using UserMicroserviceAPI.Infrastructure.DataAccess.DataContext;

namespace UserMicroserviceAPI.Infrastructure.DataAccess.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AccountDbContext _context;

        public LoginRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<Users> Login(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
       
    }

}
