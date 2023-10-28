using IdPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdPet.Domain.Interfaces.Contextos;

public interface IPerfilContext
{
    DbSet<Account> Contas { get; set; }
    DbSet<Animal> Animais { get; set; }
    DbSet<Especie> Especie { get; set; }
    DbSet<Raca> Raca { get; set; }
    int SaveChanges();
}