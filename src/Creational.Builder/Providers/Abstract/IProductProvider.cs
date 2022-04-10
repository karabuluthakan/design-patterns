namespace Creational.Builder.Providers.Abstract;

public interface IProductProvider
{
    ValueTask<Product> GetAsync(string id);
}