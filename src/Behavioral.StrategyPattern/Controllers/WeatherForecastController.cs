namespace Behavioral.StrategyPattern.Controllers;

[
    ApiController,
    Route("[controller]"),
    Produces(MediaTypeNames.Application.Json)
]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public WeatherForecast[] Get([FromServices] IWeatherStrategy weatherStrategy)
    {
        return weatherStrategy.GetWeatherForecast();
    }
}