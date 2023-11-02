using IdPet.ApplicationServices.Dto.Medicamentos;
using IdPet.ApplicationServices.Interfaces;
using IdPet.ApplicationServices.Queries;
using IdPet.Domain.Entities;
using IdPet.Domain.Interfaces.Contextos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdPet.ApplicationServices.Handlers.Queries;

public class EncontrarHistoricoMedicamentosQueryHandler : IRequestHandler<EncontrarHistoricoVacinacaoQuery, IEnumerable<HistoricoMedicamentoDto>>
{
    private readonly IClinicaVeterinariaContext _contexto;
    private readonly IParser<MedicamentoAplicado, HistoricoMedicamentoDto> _parser;

    public EncontrarHistoricoMedicamentosQueryHandler(
        IClinicaVeterinariaContext contexto, 
        IParser<MedicamentoAplicado, HistoricoMedicamentoDto> parser)
    {
        _contexto = contexto;
        _parser = parser;
    }

    public async Task<IEnumerable<HistoricoMedicamentoDto>> Handle(EncontrarHistoricoVacinacaoQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<MedicamentoAplicado> historico = _contexto
            .MedicamentosAplicados
            .Include(x => x.Medicamento)
            .Where(x => x.AnimalId == request.AnimalId);

        return await _parser.Parse(historico);
    }
}