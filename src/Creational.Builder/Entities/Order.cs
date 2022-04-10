#pragma warning disable CS8618
namespace Creational.Builder.Entities;

public class Order : IEntity
{
    public Customer Customer { get; internal set; }
    public Product Product { get; internal set; }
}