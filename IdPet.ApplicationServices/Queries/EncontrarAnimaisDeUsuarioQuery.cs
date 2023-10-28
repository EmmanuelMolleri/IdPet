using IdPet.ApplicationServices.Dto.Animais;
using MediatR;

namespace IdPet.ApplicationServices.Queries;

public class EncontrarAnimaisDeUsuarioQuery : IRequest<IEnumerable<AnimalDto>>
{
    public int UsuarioId { get; set; }
}