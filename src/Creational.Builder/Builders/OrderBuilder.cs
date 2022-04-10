namespace Creational.Builder.Builders;

public class OrderBuilder : IOrderBuilder
{
    private readonly ICustomerProvider _customerProvider;
    private readonly IProductProvider _productProvider;
    private readonly IStockProvider _stockProvider;
    private readonly Order _order;

    private OrderBuilder(
        ICustomerProvider customerProvider,
        IProductProvider productProvider,
        IStockProvider stockProvider)
    {
        _customerProvider = Guard.Against.Null(customerProvider);
        _productProvider = Guard.Against.Null(productProvider);
        _stockProvider = Guard.Against.Null(stockProvider);
        _order = new Order();
    }

    public static OrderBuilder Init(
        ICustomerProvider customerProvider,
        IProductProvider productProvider,
        IStockProvider stockProvider)
    {
        return new OrderBuilder(
            customerProvider,
            productProvider,
            stockProvider);
    }

    public Order Build()
    {
        Guard.Against.Null(_order);
        Guard.Against.Null(_order?.Customer);
        Guard.Against.Null(_order?.Product);
        return _order;
    }

    public OrderBuilder SetCustomer(string id)
    {
        id = Guard.Against.NullOrEmpty(id);
        _order.Customer = _customerProvider.GetAsync(id).Result;
        return this;
    }

    public OrderBuilder SetProduct(string id)
    {
        id = Guard.Against.Null(id);
        var product = _productProvider.GetAsync(id).Result;
        var stock = _stockProvider.GetAsync(id).Result;

        if (product.Quantity > stock.OnHandQuantity)
        {
            throw new NotEnoughStockException(id);
        }

        _order.Product = product;
        return this;
    }
}