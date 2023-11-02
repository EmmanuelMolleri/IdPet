using IdPet.ApplicationServices.Dto.Animais;
using IdPet.ApplicationServices.Dto.Medicamentos;
using IdPet.ApplicationServices.Interfaces;
using IdPet.ApplicationServices.Parsers.Animais;
using IdPet.ApplicationServices.Parsers.Medicamento;
using IdPet.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace IdPet.CrossCutting;

public static class ParserDependencies
{
    public static void Inject(IServiceCollection services)
    {
        services.AddScoped<IParser<Animal, AnimalDto>, AnimalDtoParser>();
        services.AddScoped<IParser<MedicamentoAplicado, HistoricoMedicamentoDto>, MedicamentoAplicadoParser>();
    }
}
