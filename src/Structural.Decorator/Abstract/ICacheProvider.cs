namespace Structural.Decorator.Abstract;

/// <summary>
/// 
/// </summary>
public interface ICacheProvider : IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask<T> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="expiry"></param>
    /// <returns></returns>
    bool Set(string key, object data, TimeSpan? expiry = null);
}