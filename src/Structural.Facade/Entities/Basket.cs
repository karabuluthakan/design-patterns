using Structural.Facade.Entities.Abstract;

namespace Structural.Facade.Entities;

public class Basket : IEntity
{
    public Customer Customer { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}