namespace Behavioral.StrategyPattern.WeatherStrategies;

public class GermanWeatherStrategy : IWeatherStrategy
{
    public WeatherForecast[] GetWeatherForecast()
    {
        int GetTemperature()
        {
            return Random.Shared.Next(-20, 55);
        }

        string GetSummary()
        {
            return DataProvider.GermanWeatherSummaries[Random.Shared.Next(DataProvider.GermanWeatherSummaries.Length)];
        }

        string GetDayName(int index)
        {
            return DateTime.UtcNow.AddDays(index).GetDayName("de");
        }

        return Enumerable.Range(1, 7).Select(index => new WeatherForecast(
            GetTemperature(), GetSummary(), GetDayName(index))).ToArray();
    }
}