using Structural.Facade.ValueObjects.Abstract;

namespace Structural.Facade.ValueObjects;

public class Product : IValueObject
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}