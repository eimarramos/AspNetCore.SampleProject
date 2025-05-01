namespace Domain.Entities
{
    public class Pokemon
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public ICollection<string>? Types { get; set; }
        public ICollection<PokemonStat>? Stats { get; set; }
    }

    public class PokemonStat
    {
        public string? Name { get; set; }
        public int Value { get; set; }
    }
}
