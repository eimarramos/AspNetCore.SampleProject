namespace Web.Infrastructure;

public abstract class EndpointGroupBase
{
    public abstract void Map(WebApplication app);
    public abstract int Version { get; }
    public abstract EndpointName NameEnum { get; }
    public string Name => NameEnum.ToString().ToLowerInvariant();
}
