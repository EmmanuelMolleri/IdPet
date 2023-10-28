using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdPet.Domain.Interfaces.Contextos;

public interface IAcompanhamentoContext
{
    DbSet<Animal> Animais { get; set; }
    DbSet<Especie> Especie { get; set; }
    DbSet<Raca> Raca { get; set; }
    DbSet<Medicamento> Medicamentos { get; set; }
    DbSet<MedicamentoAplicado> MedicamentosAplicados { get; set; }

    int SaveChanges();
}