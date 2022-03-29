namespace Structural.AdapterPattern.Abstract;

/// <summary>
/// 
/// </summary>
public interface IMapperAdapter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TDestination"></typeparam>
    /// <returns></returns>
    TDestination Map<TDestination>(object source);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    /// <returns></returns>
    TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
}