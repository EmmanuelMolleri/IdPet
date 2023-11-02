using IdPet.ApplicationServices.Dto.Animais;
using MediatR;

namespace IdPet.ApplicationServices.Commands;

public class AdicionarPetCommand : IRequest<AnimalDto>
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public float? Peso { get; set; }
    public bool Sexo { get; set; }
    public int? DonoId { get; set; }
    public int? RacaId { get; set; }
}