#pragma warning disable CS8618
namespace Structural.Decorator.Entities;

public class WeatherForecast : Entity
{
    public int Temperature { get; private init; }
    public string Summary { get; private init; }
    public string DayName { get; private init; }

    public static WeatherForecast Create(string id, int temperature, string summary, string dayName)
    {
        return new WeatherForecast
        {
            Id = Guard.Against.NullOrEmpty(id),
            Temperature = Guard.Against.NullOrInvalidInput(
                temperature, nameof(temperature), _ => temperature is >= -25 and <= 55),
            Summary = Guard.Against.NullOrEmpty(summary?.Trim()),
            DayName = Guard.Against.NullOrEmpty(dayName?.Trim())
        };
    }

    public WeatherForecast()
    {
    }
}