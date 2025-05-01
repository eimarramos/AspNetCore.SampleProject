using Application.Pokemons.Queries.GetPokemons;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Endpoints
{
    public class Pokemons : EndpointGroupBase
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
