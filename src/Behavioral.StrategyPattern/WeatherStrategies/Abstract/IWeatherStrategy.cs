namespace Behavioral.StrategyPattern.WeatherStrategies.Abstract;

public interface IWeatherStrategy
{
    WeatherForecast[] GetWeatherForecast();
}