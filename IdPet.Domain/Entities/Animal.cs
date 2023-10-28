namespace IdPet.Domain.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public float? Peso { get; set; }
    public bool Sexo { get; set; }
    public int? DonoId { get; set; }
    public Account? Dono { get; set; }
    public int? RacaId { get; set; }
    public Raca Raca { get; set; }

    public ICollection<MedicamentoAplicado> MedicamentoAplicados = new List<MedicamentoAplicado>();
}