namespace Structural.Decorator.Abstract;

public interface IDecorator
{
    ValueTask<WeatherForecast> GetByIdAsync(string id,CancellationToken cancellationToken = default);
    ValueTask<List<WeatherForecast>> GetAllAsync(CancellationToken cancellationToken = default);
}