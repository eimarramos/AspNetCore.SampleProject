using Domain.Entities;


namespace Application.Pokemons.Queries.GetPokemons
{
    public class PokemonDto
    {
        public int Id { get; init; }
        public int PokedexNumber { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public ICollection<string>? Types { get; set; }
        public ICollection<PokemonStatDto>? Stats { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Pokemon, PokemonDto>();
            }
        }
    }

    public class PokemonStatDto
    {
        public string? Name { get; set; }
        public int Value { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<PokemonStat, PokemonStatDto>();
            }
        }
    }
}
