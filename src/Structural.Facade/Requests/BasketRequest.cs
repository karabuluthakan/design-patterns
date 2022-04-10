namespace Structural.Facade.Requests;

public class BasketRequest : IRequest
{
    public string CustomerId { get; }
    public string ProductId { get; }
    public int Quantity { get; }

    public BasketRequest(string customerId, string productId, int quantity)
    {
        CustomerId = customerId;
        ProductId = productId;
        Quantity = quantity;
    }
}