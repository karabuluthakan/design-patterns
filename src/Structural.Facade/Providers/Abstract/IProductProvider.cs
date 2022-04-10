namespace Structural.Facade.Providers.Abstract;

public interface IProductProvider
{
    ValueTask<Product> GetAsync(string productId);
}