namespace Behavioral.MediatorPattern.Query;

public class PrintToConsoleQueryRequest : IRequest<bool>
{
    public string Text { get; }

    public PrintToConsoleQueryRequest(string text)
    {
        Text = Guard.Against.NullOrEmpty(text);
    }

    public class PrintToConsoleQueryHandler : IHandler<PrintToConsoleQueryRequest, bool>
    {
        public Task<bool> HandleAsync(PrintToConsoleQueryRequest request)
        {
            Console.WriteLine($"From {nameof(PrintToConsoleQueryHandler)} {request.Text}");
            return Task.FromResult(true);
        }
    }
}