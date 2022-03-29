namespace Behavioral.MediatorPattern.Persistence.Abstract;

public interface IMediator
{
    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
}