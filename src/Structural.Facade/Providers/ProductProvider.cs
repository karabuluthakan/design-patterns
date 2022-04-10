namespace Structural.Facade.Providers;

public class ProductProvider : IProductProvider
{
    public async ValueTask<Product> GetAsync(string productId)
    {
        return new Faker<Product>()
            .RuleFor(x => x.Id, productId)
            .RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.Price, f => f.Finance.Amount())
            .Generate();
    }
}