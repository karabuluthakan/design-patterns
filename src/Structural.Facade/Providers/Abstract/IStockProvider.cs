namespace Structural.Facade.Providers.Abstract;

public interface IStockProvider
{
    ValueTask<int> GetOnHandQuantity(string productId,int quantity);
}