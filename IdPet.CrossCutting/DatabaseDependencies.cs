using IdPet.Domain.Interfaces.Contextos;
using IdPet.Infra.Data.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdPet.CrossCutting;

public static class DatabaseDependencies
{
    public static void Inject(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ZoologicoContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("zoologico"));
        });

        services.AddScoped(provider => (IAcompanhamentoContext)provider.GetRequiredService(typeof(ZoologicoContext)));
        services.AddScoped(provider => (IClinicaVeterinariaContext)provider.GetRequiredService(typeof(ZoologicoContext)));
        services.AddScoped(provider => (IPerfilContext)provider.GetRequiredService(typeof(ZoologicoContext)));
    }
}