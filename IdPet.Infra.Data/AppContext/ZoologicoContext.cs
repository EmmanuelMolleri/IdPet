using IdPet.Domain.Configuration;
using IdPet.Domain.Entities;
using IdPet.Domain.Interfaces.Contextos;
using Microsoft.EntityFrameworkCore;

namespace IdPet.Infra.Data.AppContext;

public class ZoologicoContext : DbContext, IPerfilContext, IClinicaVeterinariaContext, IAcompanhamentoContext
{
    public DbSet<Account> Contas { get; set; }
    public DbSet<Animal> Animais { get; set; }
    public DbSet<Especie> Especie { get; set; }
    public DbSet<Raca> Raca { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<MedicamentoAplicado> MedicamentosAplicados { get; set; }
    public DbSet<ClinicaVeterinaria> ClinicasVeterinarias { get; set; }

    public ZoologicoContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}