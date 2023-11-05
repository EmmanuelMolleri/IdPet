using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdPet.Infra.Data.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Contas");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.NomeUsuario)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder
            .Property(x => x.IsVeterinario)
            .HasColumnType("BIT")
            .HasDefaultValue(false);

        builder
            .Property(x => x.Crmv)
            .HasColumnType("VARCHAR(50)");

        builder
            .HasMany(x => x.Animals)
            .WithOne(x => x.Dono)
            .HasForeignKey(x => x.DonoId)
            .IsRequired(false);

        builder
            .HasOne(x => x.ClinicaVeterinaria)
            .WithMany(x => x.Veterinarios)
            .HasForeignKey(x => x.ClinicaVeterinariaId)
            .IsRequired(false);
    }
}