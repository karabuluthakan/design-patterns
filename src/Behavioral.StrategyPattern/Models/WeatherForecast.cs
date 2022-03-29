namespace Behavioral.StrategyPattern.Models;

public class WeatherForecast
{
    public int Temperature { get; }
    public string Summary { get; }
    public string DayName { get; }

    public WeatherForecast(int temperature, string summary, string dayName)
    {
        Temperature = temperature;
        Summary = summary;
        DayName = dayName;
    }
}