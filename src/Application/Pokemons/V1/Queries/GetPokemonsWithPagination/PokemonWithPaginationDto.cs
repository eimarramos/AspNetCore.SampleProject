using Domain.Entities;

namespace Application.Pokemons.V1.Queries.GetPokemonsWithPagination
{
    public class PokemonWithPaginationDto
    {
        public int Id { get; init; }
        public int PokedexNumber { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public ICollection<string>? Types { get; set; }
        public ICollection<PokemonStatWithPaginationDto>? Stats { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Pokemon, PokemonWithPaginationDto>();
            }
        }
    }

    public class PokemonStatWithPaginationDto
    {
        public string? Name { get; set; }
        public int Value { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<PokemonStat, PokemonStatWithPaginationDto>();
            }
        }
    }
}
