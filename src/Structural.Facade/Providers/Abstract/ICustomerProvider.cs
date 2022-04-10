namespace Structural.Facade.Providers.Abstract;

public interface ICustomerProvider
{
    ValueTask<Customer> GetAsync(string customerId);
}