namespace Behavioral.StrategyPattern.WeatherStrategies;

public class TurkishWeatherStrategy : IWeatherStrategy
{
    public WeatherForecast[] GetWeatherForecast()
    {
        int GetTemperature()
        {
            return Random.Shared.Next(-20, 55);
        }

        string GetSummary()
        {
            return DataProvider.TurkishWeatherSummaries
                [Random.Shared.Next(DataProvider.TurkishWeatherSummaries.Length)];
        }

        string GetDayName(int index)
        {
            return DateTime.UtcNow.AddDays(index).GetDayName("tr");
        }

        return Enumerable.Range(1, 7).Select(index => new WeatherForecast(
            GetTemperature(), GetSummary(), GetDayName(index))).ToArray();
    }
}