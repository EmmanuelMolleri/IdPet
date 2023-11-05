using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdPet.Infra.Data.Configuration;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder
            .ToTable("Animais");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Nome)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder
            .Property(x => x.DataNascimento)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder
            .Property(x => x.Peso)
            .HasColumnType("FLOAT");

        builder
            .Property(x => x.Sexo)
            .HasColumnType("BIT")
            .IsRequired();

        builder
            .HasOne(x => x.Dono)
            .WithMany(x => x.Animals)
            .HasForeignKey(x => x.DonoId);

        builder
            .HasOne(x => x.Raca)
            .WithMany(x => x.Animais)
            .HasForeignKey(x => x.RacaId);

        builder
            .HasMany(x => x.MedicamentoAplicados)
            .WithOne(x => x.Animal)
            .HasForeignKey(x => x.AnimalId);
    }
}