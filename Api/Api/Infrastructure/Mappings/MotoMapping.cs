using Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class MotoMapping : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            
            builder
                .HasKey(c => c.idMoto);

            builder
                .Property(c => c.idMoto)
                .ValueGeneratedOnAdd();

            builder
                .Property(c => c.anoDeFabricacao)
                .IsRequired();

            builder
                .Property(c => c.anoDeLancamento)
                .IsRequired();

            builder
                .Property(c => c.quilometragem)
                .IsRequired();

            builder
                .Property(c => c.placa)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(c => c.tagDaMoto)
                .HasMaxLength(50);

            builder
                .Property(c => c.chassi)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(c => c.observacao)
                .HasMaxLength(255);

            builder
                .Property(c => c.fotoDaMoto);

            builder
                .Property(c => c.ipva)
                .IsRequired();

            builder
                .Property(c => c.licenciamento)
                .IsRequired();

            builder
                .Property(c => c.dpvat)
                .IsRequired();

            builder
                .Property(c => c.combustivel)
                .IsRequired();

            builder
                .Property(c => c.typeMoto)
                .IsRequired();

            builder
                .Property(c => c.patioAtual)
                .HasMaxLength(100);

            builder
                .Property(c => c.planoAssociado)
                .HasMaxLength(100);

            builder
                .Property(c => c.multas)
                .HasMaxLength(255);

            builder
                .Property(c => c.historicoDeReparos)
                .HasMaxLength(255);

            builder
                .Property(c => c.historicoDeChecks)
                .HasMaxLength(255);

            builder
                .HasOne(c => c.user)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}