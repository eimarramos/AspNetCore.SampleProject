using Domain.Common;

namespace Domain.Entities
{
    public class Pokemon : BaseEntity
    {
        public int PokedexNumber { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public ICollection<string>? Types { get; set; }
        public ICollection<PokemonStat>? Stats { get; set; }
    }

    public class PokemonStat : BaseEntity
    {
        public Pokemon? Pokemon { get; set; }
        public string? Name { get; set; }
        public int Value { get; set; }
    }
}
