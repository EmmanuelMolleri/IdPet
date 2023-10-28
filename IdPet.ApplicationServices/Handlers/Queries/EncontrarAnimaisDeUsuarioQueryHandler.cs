using IdPet.ApplicationServices.Dto.Animais;
using IdPet.ApplicationServices.Interfaces;
using IdPet.ApplicationServices.Queries;
using IdPet.Domain.Entities;
using IdPet.Domain.Interfaces.Contextos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdPet.ApplicationServices.Handlers.Queries;

public class EncontrarAnimaisDeUsuarioQueryHandler : IRequestHandler<EncontrarAnimaisDeUsuarioQuery, IEnumerable<AnimalDto>>
{
    private readonly IPerfilContext _context;
    private readonly IParser<Animal, AnimalDto> _parser;

    public EncontrarAnimaisDeUsuarioQueryHandler(
        IPerfilContext context, 
        IParser<Animal, AnimalDto> parser)
    {
        _context = context;
        _parser = parser;
    }

    public async Task<IEnumerable<AnimalDto>> Handle(EncontrarAnimaisDeUsuarioQuery request, CancellationToken cancellationToken)
    {
        var animaisEncontrados = _context
            .Animais
                .Include(x => x.Dono)
            .Where(x => x.Dono.Id == request.UsuarioId);

        if (animaisEncontrados == null)
        {
            return new List<AnimalDto>();
        }

        return await _parser.Parse(animaisEncontrados);
    }
}