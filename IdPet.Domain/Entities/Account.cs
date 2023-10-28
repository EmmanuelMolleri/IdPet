namespace IdPet.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string NomeUsuario { get; set; }
    public bool IsVeterinario { get; set; }
    public string? Crmv { get; set; }

    public ICollection<Animal> Animals = new List<Animal>();
    public int? ClinicaVeterinariaId { get; set; }
    public ClinicaVeterinaria? ClinicaVeterinaria { get; set; }
}