namespace Creational.Builder.Providers.Abstract;

public interface ICustomerProvider
{
    ValueTask<Customer> GetAsync(string id);
}