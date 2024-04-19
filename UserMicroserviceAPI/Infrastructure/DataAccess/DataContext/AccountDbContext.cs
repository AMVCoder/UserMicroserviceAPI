using Microsoft.EntityFrameworkCore;
using System;
using UserMicroserviceAPI.Core.Entities.Users;

namespace UserMicroserviceAPI.Infrastructure.DataAccess.DataContext
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Users>().HasKey(u => u.UserId);
        modelBuilder.Entity<Users>().Property(u => u.Email).IsRequired();
    }
}
}
