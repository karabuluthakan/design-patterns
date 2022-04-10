namespace Creational.Builder.Entities.ValueObjects;

public class Address : IValueObject
{
    public string Id { get; init; }
    public string Country { get; init; }
    public string County { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string ZipCode { get; init; }
}