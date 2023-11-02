
namespace IdPet.ApplicationServices.Dto.Medicamentos;

public record HistoricoMedicamentoDto(int MedicamentoId, string MedicamentoNome, float Dosagem, DateTime DataHoraAcontecimento);