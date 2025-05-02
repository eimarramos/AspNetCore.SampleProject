using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;

namespace Application.Pokemons.V1.Queries.GetPokemonsWithPagination;

public record GetPokemonsWithPaginationQuery : IRequest<PaginatedList<PokemonWithPaginationDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPokemonsWithPaginationQueryHandler : IRequestHandler<GetPokemonsWithPaginationQuery, PaginatedList<PokemonWithPaginationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetPokemonsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<PokemonWithPaginationDto>> Handle(GetPokemonsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Pokemons
        .AsNoTracking()
        .OrderBy(x => x.PokedexNumber)
        .ProjectTo<PokemonWithPaginationDto>(_mapper.ConfigurationProvider)
        .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

