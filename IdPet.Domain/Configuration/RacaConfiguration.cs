using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdPet.Domain.Configuration;

public class RacaConfiguration : IEntityTypeConfiguration<Raca>
{
    public void Configure(EntityTypeBuilder<Raca> builder)
    {
        builder
            .ToTable("Racas");

        builder
            .Property(x => x.Nome)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder
            .HasOne(x => x.Especie)
            .WithMany(x => x.Racas)
            .HasForeignKey(x => x.EspecieId);

        builder
            .HasMany(x => x.Animais)
            .WithOne(x => x.Raca)
            .HasForeignKey(x => x.RacaId);
    }
}