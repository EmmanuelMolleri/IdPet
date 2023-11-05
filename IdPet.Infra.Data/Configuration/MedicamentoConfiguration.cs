using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdPet.Infra.Data.Configuration;

public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder
            .ToTable("Medicamentos");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Nome)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder
            .Property(x => x.IsOral)
            .HasColumnType("BIT")
            .IsRequired();

        builder
            .HasMany(x => x.MedicamentoAplicados)
            .WithOne(x => x.Medicamento)
            .HasForeignKey(x => x.MedicamentoId);
    }
}