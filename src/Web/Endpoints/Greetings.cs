
using Application.Queries;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Endpoints
{
    public class Greetings : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapGet(GetGreetings);
        }
        public async Task<Ok<string>> GetGreetings(ISender sender)
        {
            var result = await sender.Send(new GetHelloQuery());

            return TypedResults.Ok(result);
        }
    }
}
