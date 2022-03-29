// See https://aka.ms/new-console-template for more information

const string text = "Hello, World!";

var serviceProvider = new ServiceCollection()
    .AddMediator(ServiceLifetime.Scoped, typeof(Program))
    .BuildServiceProvider();

var mediator = serviceProvider.GetRequiredService<IMediator>();

mediator.SendAsync(new PrintToConsoleCommandRequest(text));
mediator.SendAsync(new PrintToConsoleQueryRequest(text));