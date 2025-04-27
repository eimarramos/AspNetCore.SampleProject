namespace Application.Queries
{
    public record GetHelloQuery : IRequest<string>;

    public class GetHelloQueryHandler : IRequestHandler<GetHelloQuery, string>
    {
        public Task<string> Handle(GetHelloQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult("¡Hola desde Application!");
        }
    }
}
