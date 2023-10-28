namespace IdPet.Domain.Entities;

public class Especie
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ICollection<Raca> Racas = new List<Raca>();
}