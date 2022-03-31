namespace Structural.Decorator.DataAccess;

public class CacheDecorator : IDecorator
{
    private readonly ICacheProvider _cache;
    private readonly IRepository _repository;

    public CacheDecorator(ICacheProvider cache, IRepository repository)
    {
        _cache = Guard.Against.Null(cache);
        _repository = Guard.Against.Null(repository);
    }

    public async ValueTask<WeatherForecast> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var key = $"{id}_weather_forecast";
        var cacheData = await _cache.GetAsync<WeatherForecast>(key, cancellationToken);
        if (cacheData is null)
        {
            var data = await _repository.GetByIdAsync(id, cancellationToken);
            if (data is null)
            {
                return data;
            }

            _cache.Set(key, data, TimeSpan.FromMinutes(30));
            return data;
        }

        return cacheData;
    }

    public async ValueTask<List<WeatherForecast>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        const string key = "all_weather_forecast";
        var cacheData = await _cache.GetAsync<List<WeatherForecast>>(key, cancellationToken);
        if (cacheData is null)
        {
            var data = await _repository.GetAllAsync(cancellationToken);
            if (data is not null && data.Any())
            {
                _cache.Set(key, data, TimeSpan.FromMinutes(30));
            }

            return data;
        }

        return cacheData;
    }
}