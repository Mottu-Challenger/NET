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
                .HasKey(u => u.idUser);

            builder
                .Property(u => u.idUser)
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.cpf)
                .HasMaxLength(14)
                .IsRequired();

            builder
                .Property(u => u.rg)
                .HasMaxLength(20);

            builder
                .Property(u => u.dtaNasc)
                .IsRequired();

            builder
                .Property(u => u.numeroDeCadastro)
                .IsRequired();

            builder
                .Property(u => u.ativo)
                .IsRequired();

            builder
                .Property(u => u.nacionalidade)
                .HasMaxLength(50);

            builder
                .Property(u => u.carteira)
                .HasMaxLength(50);

            builder
                .Property(u => u.enderco)
                .HasMaxLength(100);

            builder
                .Property(u => u.contato)
                .HasMaxLength(100);

            builder
                .Property(u => u.plano)
                .HasMaxLength(100);

            builder
                .HasOne(u => u.motos)
                .WithOne()
                .HasForeignKey<Moto>("UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
