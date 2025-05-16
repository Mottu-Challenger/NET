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
                .HasKey(c => c.IDMoto);

            builder
                .Property(c => c.IDMoto)
                .ValueGeneratedOnAdd();

            builder
                .Property(c => c.AnoDeFabricacao)
                .IsRequired();

            builder
                .Property(c => c.AnoDelançamento)
                .IsRequired();

            builder
                .Property(c => c.Quilometragem)
                .IsRequired();

            builder
                .Property(c => c.Placa)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(c => c.TagDaMoto)
                .HasMaxLength(50);

            builder
                .Property(c => c.Chassi)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(c => c.Observacao)
                .HasMaxLength(255);

            builder
                .Property(c => c.FotoDaMoto);

            builder
                .Property(c => c.IPVA)
                .IsRequired();

            builder
                .Property(c => c.Licenciamento)
                .IsRequired();

            builder
                .Property(c => c.DPVAT)
                .IsRequired();

            builder
                .Property(c => c.Combustivel)
                .IsRequired();

            builder
                .Property(c => c.TypeMoto)
                .IsRequired();

            builder
                .Property(c => c.PatioAtual)
                .HasMaxLength(100);

            builder
                .Property(c => c.PlanoAssociado)
                .HasMaxLength(100);

            builder
                .Property(c => c.Multas)
                .HasMaxLength(255);

            builder
                .Property(c => c.HistoricoDeReparos)
                .HasMaxLength(255);

            builder
                .Property(c => c.HistoricoDeChecks)
                .HasMaxLength(255);

            // Relacionamento com User (1:N)
            builder
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}