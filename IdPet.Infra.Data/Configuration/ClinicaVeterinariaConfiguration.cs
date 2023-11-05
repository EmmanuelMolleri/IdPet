using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdPet.Infra.Data.Configuration;

public class ClinicaVeterinariaConfiguration : IEntityTypeConfiguration<ClinicaVeterinaria>
{
    public void Configure(EntityTypeBuilder<ClinicaVeterinaria> builder)
    {
        builder
            .ToTable("ClinicasVeterinarias");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Nome)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder
            .Property(x => x.Cnpj)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder
            .HasMany(x => x.Veterinarios)
            .WithOne(x => x.ClinicaVeterinaria)
            .HasForeignKey(x => x.ClinicaVeterinariaId);
    }
}