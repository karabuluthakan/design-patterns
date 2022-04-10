namespace Creational.Builder.Providers;

public class CustomerProvider : ICustomerProvider
{
    public async ValueTask<Customer> GetAsync(string id)
    {
        var random = new Random();
        var address = new Faker<Address>()
            .RuleFor(x => x.Id, f => f.Random.Guid().ToString("N"))
            .RuleFor(x => x.City, f => f.Address.City())
            .RuleFor(x => x.Country, f => f.Address.Country())
            .RuleFor(x => x.County, f => f.Address.County())
            .RuleFor(x => x.Street, f => f.Address.StreetAddress())
            .RuleFor(x => x.ZipCode, f => f.Address.ZipCode())
            .Generate(random.Next(1, 3));
        
        var customer = new Faker<Customer>()
            .RuleFor(x => x.Id, f => id)
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Email, f => f.Person.Email)
            .Generate();
        
        customer.Addresses.AddRange(address);
        return customer;
    }
}