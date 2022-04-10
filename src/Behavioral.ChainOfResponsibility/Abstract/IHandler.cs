namespace Behavioral.ChainOfResponsibility.Abstract;

public interface IHandler
{
    IHandler SetNext(IHandler handler);
    Resume Handle(Resume request);
}