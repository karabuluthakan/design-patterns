namespace Behavioral.StrategyPattern.WeatherStrategies;

public class EnglishWeatherStrategy : IWeatherStrategy
{
    public WeatherForecast[] GetWeatherForecast()
    {
        int GetTemperature()
        {
            var celsius = Random.Shared.Next(-20, 55);
            var fahrenheit = 32 + (int)(celsius / 0.5556);
            return fahrenheit;
        }

        string GetSummary()
        {
            return DataProvider.EnglishWeatherSummaries
                [Random.Shared.Next(DataProvider.EnglishWeatherSummaries.Length)];
        }

        string GetDayName(int index)
        {
            return DateTime.UtcNow.AddDays(index).GetDayName("en");
        }

        return Enumerable.Range(1, 7).Select(index => new WeatherForecast(
            GetTemperature(), GetSummary(), GetDayName(index))).ToArray();
    }
}