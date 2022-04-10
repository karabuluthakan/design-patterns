namespace Creational.Builder.Entities.ValueObjects;

public class Product : IValueObject
{
    public string Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; set; }
    public decimal Price { get; init; }
    public Supplier Supplier { get; init; }
}