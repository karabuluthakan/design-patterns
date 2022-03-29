namespace Structural.AdapterPattern.Mapster;

public class MapsterProfile
{
    public static TypeAdapterConfig CreateMap()
    {
        var config = new TypeAdapterConfig();

        config.NewConfig<ExampleCreateDto, ExampleModel>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Date, src => new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day));

        return config;
    }
}