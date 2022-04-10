namespace Creational.Builder.Entities.ValueObjects;

public class Customer : IValueObject
{
    public string Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public List<Address> Addresses { get; set; } = new();
}