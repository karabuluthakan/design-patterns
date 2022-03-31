// ReSharper disable All

#pragma warning disable CS1998
#pragma warning disable CS8603
namespace Structural.Decorator.DataAccess;

public class FakeWeatherForecastRepository : IRepository
{
    private List<WeatherForecast> _weatherForecasts;

    public FakeWeatherForecastRepository()
    {
        _weatherForecasts = new List<WeatherForecast>(Setup());
    }

    public async ValueTask<WeatherForecast> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return _weatherForecasts.Where(x => x.Id.Equals(id)).FirstOrDefault();
    }

    public async ValueTask<List<WeatherForecast>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _weatherForecasts;
    }

    public async ValueTask AddAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken = default)
    {
        _weatherForecasts.Add(weatherForecast);
    }

    private List<WeatherForecast> Setup()
    {
        int GetTemperature()
        {
            return Random.Shared.Next(-25, 55);
        }

        (string, string) GetSummaryAndDayName(int index, string location)
        {
            var summary = location switch
            {
                "uk" => DataProvider.EnglishWeatherSummaries[
                    Random.Shared.Next(DataProvider.EnglishWeatherSummaries.Length)],
                "de" => DataProvider.GermanWeatherSummaries[
                    Random.Shared.Next(DataProvider.GermanWeatherSummaries.Length)],
                _ => DataProvider.TurkishWeatherSummaries[
                    Random.Shared.Next(DataProvider.TurkishWeatherSummaries.Length)]
            };
            var dayName = DateTime.UtcNow.AddDays(index).GetDayName(location);
            return (summary, dayName);
        }

        var list = new List<WeatherForecast>(30);

        for (var index = 1; index <= 21; index++)
        {
            var location = index switch
            {
                >= 7 and < 14 => "uk",
                >= 14 => "de",
                _ => "tr"
            };

            var (summary, dayName) = GetSummaryAndDayName(index, location);

            list.Add(WeatherForecast.Create(index.ToString(), GetTemperature(), summary, dayName));
        }

        return list;
    }
}