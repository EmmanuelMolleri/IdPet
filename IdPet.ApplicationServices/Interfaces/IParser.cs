namespace IdPet.ApplicationServices.Interfaces;

public interface IParser<T, G>
{
    Task<T> Parse(G objeto);

    Task<G> Parse(T objeto);

    async Task<IEnumerable<T>> Parse(IEnumerable<G> objeto)
        => await Task.WhenAll(objeto.Select(Parse));

    async Task<IEnumerable<G>> Parse(IEnumerable<T> objeto)
        => await Task.WhenAll(objeto.Select(Parse));
}