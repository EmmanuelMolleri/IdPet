using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdPet.Domain.Interfaces.Contextos;

public interface IClinicaVeterinariaContext
{
    DbSet<ClinicaVeterinaria> ClinicasVeterinarias { get; set; }
    DbSet<Account> Contas { get; set; }
    DbSet<Animal> Animais { get; set; }
    DbSet<Especie> Especie { get; set; }
    DbSet<Raca> Raca { get; set; }
    DbSet<Medicamento> Medicamentos { get; set; }
    DbSet<MedicamentoAplicado> MedicamentosAplicados { get; set; }
    int SaveChanges();
}