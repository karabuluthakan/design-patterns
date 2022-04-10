namespace Creational.Builder.Providers;

public class ProductProvider : IProductProvider
{
    public async ValueTask<Product> GetAsync(string id)
    {
        return new Faker<Product>()
            .RuleFor(x => x.Id, f => id)
            .RuleFor(x => x.Name, f => f.Commerce.Product())
            .RuleFor(x => x.Quantity, f => f.UniqueIndex)
            .RuleFor(x => x.Price, f => f.Random.Decimal())
            .RuleFor(x => x.Supplier, f => new Supplier
            {
                Id = f.Random.Guid().ToString(),
                Name = f.Company.CompanyName()
            })
            .Generate();
    }
}