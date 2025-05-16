using Api.Domain.Entity;
using Api.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Context
{

    public class MotosContext(DbContextOptions<MotosContext> options) : DbContext(options)
    {
        public DbSet<Moto> Motos { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotoMapping());
        }
    }
}