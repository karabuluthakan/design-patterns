namespace Creational.Builder.Exceptions;

public class NotEnoughStockException : Exception
{
    public NotEnoughStockException(string productId) : base($"{productId} is not enough stock")
    {
    }
}