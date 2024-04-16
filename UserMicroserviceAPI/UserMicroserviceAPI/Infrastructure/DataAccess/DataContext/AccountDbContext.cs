using Microsoft.EntityFrameworkCore;
using System;
using UserMicroserviceAPI.Core.Entities.User;

namespace UserMicroserviceAPI.Infrastructure.DataAccess.DataContext
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
        }
    }
}
