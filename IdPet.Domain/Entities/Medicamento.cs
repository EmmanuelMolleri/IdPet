namespace IdPet.Domain.Entities;

public class Medicamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public bool IsOral { get; set; }

    public ICollection<MedicamentoAplicado> MedicamentoAplicados = new List<MedicamentoAplicado>();
}