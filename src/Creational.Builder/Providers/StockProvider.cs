namespace Creational.Builder.Providers;

public class StockProvider : IStockProvider
{
    public async ValueTask<Stock> GetAsync(string productId)
    {
        return new Faker<Stock>()
            .RuleFor(x => x.Id, f => productId)
            .RuleFor(x => x.OnHandQuantity, f => f.Random.Int())
            .Generate();
    }
}