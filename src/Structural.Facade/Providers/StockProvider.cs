namespace Structural.Facade.Providers;

public class StockProvider : IStockProvider
{
    public async ValueTask<int> GetOnHandQuantity(string productId, int quantity)
    {
        var random = new Random();
        return random.Next(1, 5);
    }
}