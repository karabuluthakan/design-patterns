namespace Creational.Builder.Entities.ValueObjects;

public class Stock : IValueObject
{
    public string Id { get; init; }
    public int OnHandQuantity { get; init; }
}
 