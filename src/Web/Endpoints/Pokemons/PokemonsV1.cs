using Application.Pokemons.V1.Queries.GetPokemons;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Endpoints.Pokemons
{
    public class PokemonsV1 : EndpointGroupBase
    {
        public override int Version => 1;
        public override EndpointName NameEnum => EndpointName.Pokemon;
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapGet(GetPokemons);
        }
        public async Task<Ok<PokemonsVm>> GetPokemons(ISender sender)
        {
            var result = await sender.Send(new GetPokemonsQuery());

            return TypedResults.Ok(result);
        }
    }
}
