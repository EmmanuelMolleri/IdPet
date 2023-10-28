namespace IdPet.ApplicationServices.Dto.Animais;

public record AnimalDto(int id, string nome, DateTime dataNascimento, float peso, bool sexo);