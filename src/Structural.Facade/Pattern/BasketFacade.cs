namespace Structural.Facade.Pattern;

public class BasketFacade : IBasketFacade
{
    private readonly ICustomerProvider _customerProvider;
    private readonly IProductProvider _productProvider;
    private readonly IStockProvider _stockProvider;
    private readonly ICampaignProvider _campaignProvider;

    public BasketFacade(
        ICustomerProvider customerProvider,
        IProductProvider productProvider,
        IStockProvider stockProvider,
        ICampaignProvider campaignProvider)
    {
        _customerProvider = customerProvider;
        _productProvider = productProvider;
        _stockProvider = stockProvider;
        _campaignProvider = campaignProvider;
    }

    public async ValueTask<Basket> GetBasketAsync(BasketRequest request)
    {
        var customerTask = _customerProvider.GetAsync(request.CustomerId);
        var productTask = _productProvider.GetAsync(request.ProductId);
        var stockTask = _stockProvider.GetOnHandQuantity(request.ProductId, request.Quantity);
        await Task.WhenAll(customerTask.AsTask(), productTask.AsTask(), stockTask.AsTask());
        var product = await productTask;
        var stock = await stockTask;
        var customer = await customerTask;
        var campaignAppliedProduct = await _campaignProvider.GetCampaignAsync(product);
        var quantity = request.Quantity;
        if (request.Quantity > stock)
        {
            quantity = stock;
        }

        return new Basket
        {
            Customer = customer,
            Product = campaignAppliedProduct,
            Quantity = quantity
        };
    }
}