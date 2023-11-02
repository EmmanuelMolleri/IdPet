using IdPet.ApplicationServices.Dto.Medicamentos;
using MediatR;

namespace IdPet.ApplicationServices.Queries;

public class EncontrarHistoricoVacinacaoQuery : IRequest<IEnumerable<HistoricoMedicamentoDto>>
{
    public int AnimalId { get; set; }
}