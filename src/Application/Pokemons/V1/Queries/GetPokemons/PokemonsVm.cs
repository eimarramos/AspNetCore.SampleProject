namespace Application.Pokemons.V1.Queries.GetPokemons
{
    public class PokemonsVm
    {
        public IReadOnlyCollection<PokemonDto> Pokemons { get; init; } = Array.Empty<PokemonDto>();
    }
}
