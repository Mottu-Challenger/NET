using Api.Domain.Entity;
using Api.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Context
{
    public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}