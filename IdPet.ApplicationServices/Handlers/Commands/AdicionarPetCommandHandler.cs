using IdPet.ApplicationServices.Commands;
using IdPet.ApplicationServices.Dto.Animais;
using IdPet.ApplicationServices.Interfaces;
using IdPet.Domain.Entities;
using IdPet.Domain.Exceptions;
using IdPet.Domain.Interfaces.Contextos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace IdPet.ApplicationServices.Handlers.Commands;

public class AdicionarPetCommandHandler : IRequestHandler<AdicionarPetCommand, AnimalDto>
{
    private readonly IPerfilContext _contexto;
    private readonly IParser<Animal, AnimalDto> _parser;

    public AdicionarPetCommandHandler(IPerfilContext contexto, IParser<Animal, AnimalDto> parser)
    {
        _contexto = contexto;
        _parser = parser;
    }

    public async Task<AnimalDto> Handle(AdicionarPetCommand request, CancellationToken cancellationToken)
    {
        StringBuilder erros = new StringBuilder();
        Account? dono = await _contexto.Contas.FirstOrDefaultAsync(x => x.Id == request.DonoId);
        Raca? raca = await _contexto.Raca.FirstOrDefaultAsync(x => x.Id == request.RacaId);

        if (request.Nome.Count() < 2)
        {
            erros.AppendLine("O nome do animal deve conter pelo menos 2 caracteres.");
        }

        if (request.Nome.Count() > 20)
        {
            erros.AppendLine("O nome do animal deve conter no máximo 20 caracteres.");
        }

        if (raca == null)
        {
            erros.AppendLine("Raça não encontrada, favor validar as informações e tente novamente mais tarde.");
        }

        if (dono == null)
        {
            erros.AppendLine("Dono encontrado, favor validar as informações e tente novamente mais tarde.");
        }

        if (!string.IsNullOrEmpty(erros.ToString()))
        {
            throw new BusinessException(erros.ToString());
        }

        Animal animal = new Animal
        {
            DataNascimento = request.DataNascimento,
            Dono = dono,
            DonoId = dono.Id,
            Raca = raca,
            RacaId = raca.Id,
            Nome =  request.Nome,
            Peso = request.Peso,
            Sexo =  request.Sexo
        };

        await _contexto.Animais.AddAsync(animal);
        _contexto.SaveChanges();

        return await _parser.Parse(animal);
    }
}