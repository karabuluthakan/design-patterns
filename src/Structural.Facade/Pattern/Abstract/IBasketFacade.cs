namespace Structural.Facade.Pattern.Abstract;

public interface IBasketFacade
{
    ValueTask<Basket> GetBasketAsync(BasketRequest request);
}