namespace Behavioral.MediatorPattern.Command;

public class PrintToConsoleCommandRequest : IRequest<bool>
{
    public string Text { get; }

    public PrintToConsoleCommandRequest(string text)
    {
        Text = Guard.Against.NullOrEmpty(text);
    }

    public class PrintToConsoleCommandHandler : IHandler<PrintToConsoleCommandRequest, bool>
    {
        public Task<bool> HandleAsync(PrintToConsoleCommandRequest request)
        {
            Console.WriteLine($"From {nameof(PrintToConsoleCommandHandler)} {request.Text}");
            return Task.FromResult(true);
        }
    }
}