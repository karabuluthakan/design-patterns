#pragma warning disable CS8603

namespace Structural.AdapterPattern.AutoMapper;

public class AutoMapperAdapter : IMapperAdapter
{
    private readonly IMapper _mapper;

    public AutoMapperAdapter(IMapper mapper)
    {
        _mapper = Guard.Against.Null(mapper);
    }

    public TDestination Map<TDestination>(object source)
    {
        if (source is null)
        {
            return default;
        }

        return _mapper.Map<TDestination>(source);
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        if (source is null)
        {
            return destination;
        }

        return _mapper.Map(source, destination);
    }
}