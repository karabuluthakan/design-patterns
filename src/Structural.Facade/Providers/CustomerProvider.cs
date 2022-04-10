namespace Structural.Facade.Providers;

public class CustomerProvider : ICustomerProvider
{
    public async ValueTask<Customer> GetAsync(string customerId)
    {
        return new Faker<Customer>()
            .RuleFor(x => x.Id, customerId)
            .RuleFor(x => x.FistName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.City, f => f.Address.City())
            .RuleFor(x => x.Street, f => f.Address.StreetAddress())
            .RuleFor(x => x.ZipCode, f => f.Address.ZipCode())
            .Generate();
    }
}