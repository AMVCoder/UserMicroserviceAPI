using Microsoft.EntityFrameworkCore;
using System;
using UserMicroserviceAPI.Core.Entities.User;
using UserMicroserviceAPI.Core.Interfaces;
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

        public async Task<User> Login(string username, string password)
        {
            return await _context.Users
               .FirstOrDefaultAsync(u => u.Username == username);
        }
       
    }

}
