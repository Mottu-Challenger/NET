using Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .HasKey(u => u.IDUser);

            builder
                .Property(u => u.IDUser)
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.CPF)
                .HasMaxLength(14)
                .IsRequired();

            builder
                .Property(u => u.RG)
                .HasMaxLength(20);

            builder
                .Property(u => u.DtaNasc)
                .IsRequired();

            builder
                .Property(u => u.NumeroDeCadastro)
                .IsRequired();

            builder
                .Property(u => u.Ativo)
                .IsRequired();

            builder
                .Property(u => u.Nacionalidade)
                .HasMaxLength(50);

            builder
                .Property(u => u.Carteira)
                .HasMaxLength(50);

            builder
                .Property(u => u.Enderco)
                .HasMaxLength(100);

            builder
                .Property(u => u.Contato)
                .HasMaxLength(100);

            builder
                .Property(u => u.Plano)
                .HasMaxLength(100);

            builder
                .HasOne(u => u.Motos)
                .WithOne() // ou .WithMany() se for 1:N
                .HasForeignKey<Moto>("UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
