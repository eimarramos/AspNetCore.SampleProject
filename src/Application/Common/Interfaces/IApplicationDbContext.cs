using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Pokemon> Pokemons { get; }

    DbSet<PokemonStat> PokemonStats { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
