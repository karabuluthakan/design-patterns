#pragma warning disable CS8603
namespace Structural.AdapterPattern.Mapster;

public class MapsterMapperAdapter : IMapperAdapter
{
    public TDestination Map<TDestination>(object source)
    {
        if (source is null)
        {
            return default;
        }

        return source.Adapt<TDestination>();
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        if (source is null)
        {
            return destination;
        }

        return source.Adapt(destination);
    }
}