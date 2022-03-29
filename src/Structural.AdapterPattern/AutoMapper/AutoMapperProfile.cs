namespace Structural.AdapterPattern.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ExampleCreateDto, ExampleModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForPath(dest => dest.Date, opt => opt.MapFrom(
                src => new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)))
            .ReverseMap();
    }
}