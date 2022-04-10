namespace Creational.Builder.Providers.Abstract;

public interface IStockProvider
{
    ValueTask<Stock> GetAsync(string productId);
}