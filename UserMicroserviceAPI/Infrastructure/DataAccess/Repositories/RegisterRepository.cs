using Microsoft.EntityFrameworkCore;
using UserMicroserviceAPI.Core.Entities.Users;
using UserMicroserviceAPI.Core.Interfaces.Account.Register;
using UserMicroserviceAPI.Infrastructure.DataAccess.DataContext;

namespace UserMicroserviceAPI.Infrastructure.DataAccess.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AccountDbContext _context;

        public RegisterRepository(AccountDbContext context)
        {
            _context = context;
        }


        public async Task AddUser(Users newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckUserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
