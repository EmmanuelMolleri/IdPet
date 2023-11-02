using IdPet.ApplicationServices.Dto.Medicamentos;
using IdPet.ApplicationServices.Interfaces;
using IdPet.Domain.Entities;

namespace IdPet.ApplicationServices.Parsers.Medicamento;

public class MedicamentoAplicadoParser : IParser<MedicamentoAplicado, HistoricoMedicamentoDto>
{
    public Task<MedicamentoAplicado> Parse(HistoricoMedicamentoDto objeto)
    {
        throw new NotImplementedException();
    }

    public async Task<HistoricoMedicamentoDto> Parse(MedicamentoAplicado objeto)
    {
        return await Task.FromResult(new HistoricoMedicamentoDto(objeto.MedicamentoId, objeto.Medicamento.Nome, objeto.Dosagem, objeto.DateTime));
    }
}