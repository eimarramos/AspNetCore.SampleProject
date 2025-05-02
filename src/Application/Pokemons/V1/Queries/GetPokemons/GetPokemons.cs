using Application.Common.Interfaces;

namespace Application.Pokemons.V1.Queries.GetPokemons;

public record GetPokemonsQuery : IRequest<PokemonsVm>;

public class GetPokemonsQueryHandler : IRequestHandler<GetPokemonsQuery, PokemonsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPokemonsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PokemonsVm> Handle(GetPokemonsQuery request, CancellationToken cancellationToken)
    {
        return new PokemonsVm
        {
            Pokemons = await _context.Pokemons
            .AsNoTracking()
            .ProjectTo<PokemonDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken)
        };
    }
}

