using Structural.Facade.ValueObjects.Abstract;

namespace Structural.Facade.ValueObjects;

public class Customer : IValueObject
{
    public string Id { get; set; }
    public string FistName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
}