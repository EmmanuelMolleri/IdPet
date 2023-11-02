using IdPet.ApplicationServices.Commands;
using IdPet.ApplicationServices.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace IdPet.CrossCutting;

public static class MediatorDependencies
{
    public static void Inject(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EncontrarAnimaisDeUsuarioQuery).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EncontrarHistoricoVacinacaoQuery).Assembly));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AdicionarPetCommand).Assembly));
    }
}