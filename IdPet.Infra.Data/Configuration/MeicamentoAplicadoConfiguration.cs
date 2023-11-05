using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdPet.Infra.Data.Configuration;

public class MeicamentoAplicadoConfiguration : IEntityTypeConfiguration<MedicamentoAplicado>
{
    public void Configure(EntityTypeBuilder<MedicamentoAplicado> builder)
    {
        builder
            .ToTable("MedicamentosAplicados");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.DateTime)
            .HasColumnType("DATETIME")
            .HasDefaultValue(DateTime.Now);

        builder
            .Property(x => x.Dosagem)
            .HasColumnType("DECIMAL")
            .HasDefaultValue(0);

        builder
            .HasOne(x => x.Animal)
            .WithMany(x => x.MedicamentoAplicados)
            .HasForeignKey(x => x.AnimalId);

        builder
            .HasOne(x => x.Medicamento)
            .WithMany(x => x.MedicamentoAplicados)
            .HasForeignKey(x => x.MedicamentoId);
    }
}