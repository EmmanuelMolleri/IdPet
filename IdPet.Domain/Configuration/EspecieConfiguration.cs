using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdPet.Domain.Configuration;

public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
{
    public void Configure(EntityTypeBuilder<Especie> builder)
    {
        builder
            .ToTable("Especies");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Nome)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder
            .HasMany(x => x.Racas)
            .WithOne(x => x.Especie)
            .HasForeignKey(x => x.EspecieId);
    }
}