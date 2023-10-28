namespace IdPet.Domain.Entities;

public class MedicamentoAplicado
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public Animal Animal { get; set; }
    public int MedicamentoId { get; set; }
    public Medicamento Medicamento { get; set; }
    public DateTime DateTime { get; set; }
}