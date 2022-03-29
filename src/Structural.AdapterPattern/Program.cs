// See https://aka.ms/new-console-template for more information

var serviceProvider = new ServiceCollection()
    .AddSingleton(new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfile()); }).CreateMapper())
    .AddSingleton(MapsterProfile.CreateMap())
    .BuildServiceProvider();