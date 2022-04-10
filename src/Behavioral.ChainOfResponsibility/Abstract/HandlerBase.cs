#pragma warning disable CS8603
namespace Behavioral.ChainOfResponsibility.Abstract;

public abstract class HandlerBase : IHandler
{
    private IHandler _next;
    
    public IHandler SetNext(IHandler handler)
    {
        _next = handler;
        return handler;
    }

    public virtual Resume Handle(Resume request)
    {
        return _next?.Handle(request);
    }
}