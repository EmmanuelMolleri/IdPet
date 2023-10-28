using IdPet.ApplicationServices.Dto.Animais;
using IdPet.ApplicationServices.Interfaces;
using IdPet.Domain.Entities;

namespace IdPet.ApplicationServices.Parsers.Animais;

public class AnimalDtoParser : IParser<Animal, AnimalDto>
{
    public async Task<Animal> Parse(AnimalDto objeto)
    {
        return await Task.FromResult(new Animal
        {
            Id = objeto.id,
            Nome = objeto.nome,
            DataNascimento = objeto.dataNascimento,
            Peso = objeto.peso,
            Sexo = objeto.sexo
        });
    }

    public async Task<AnimalDto> Parse(Animal objeto)
    {
        return await Task.FromResult(new AnimalDto(objeto.Id, objeto.Nome, objeto.DataNascimento, objeto.Peso ?? 0, objeto.Sexo));
    }
}