namespace Structural.Decorator.Controllers;

[
    ApiController,
    Route("[controller]"),
    Produces(MediaTypeNames.Application.Json)
]
public class WeatherForecastController : ControllerBase
{
    private readonly IDecorator _decorator;

    public WeatherForecastController(IDecorator decorator) => _decorator = Guard.Against.Null(decorator);

    [HttpGet("id")]
    public async ValueTask<IActionResult> Show(string id, CancellationToken cancellationToken = default)
    {
        var data = await _decorator.GetByIdAsync(id, cancellationToken);
        if (data is null)
        {
            return NotFound();
        }

        return Ok(data);
    }

    [HttpGet]
    public async ValueTask<IActionResult> Index(CancellationToken cancellationToken = default)
    {
        var data = await _decorator.GetAllAsync(cancellationToken);
        return Ok(data);
    }
}