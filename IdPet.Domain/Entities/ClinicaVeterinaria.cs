namespace IdPet.Domain.Entities;

public class ClinicaVeterinaria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }

    public ICollection<Account> Veterinarios = new List<Account>();
}