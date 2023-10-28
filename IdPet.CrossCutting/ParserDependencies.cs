using IdPet.ApplicationServices.Dto.Animais;
using IdPet.ApplicationServices.Interfaces;
using IdPet.ApplicationServices.Parsers.Animais;
using IdPet.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace IdPet.CrossCutting;

public static class ParserDependencies
{
    public static void Inject(IServiceCollection services)
    {
        services.AddScoped<IParser<Animal, AnimalDto>, AnimalDtoParser>();
    }
}
