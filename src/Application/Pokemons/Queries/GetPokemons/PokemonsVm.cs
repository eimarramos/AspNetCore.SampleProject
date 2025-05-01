namespace Application.Pokemons.Queries.GetPokemons
{
    public class PokemonsVm
    {
        public IReadOnlyCollection<PokemonDto> Pokemons { get; init; } = Array.Empty<PokemonDto>();
    }
}
