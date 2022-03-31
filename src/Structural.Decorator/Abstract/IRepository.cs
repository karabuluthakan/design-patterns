namespace Structural.Decorator.Abstract;

public interface IRepository
{
    ValueTask<WeatherForecast> GetByIdAsync(string id,CancellationToken cancellationToken = default);
    ValueTask<List<WeatherForecast>> GetAllAsync(CancellationToken cancellationToken = default);
    ValueTask AddAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken = default);
}