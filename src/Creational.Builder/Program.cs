// See https://aka.ms/new-console-template for more information

var services = new ServiceCollection()
    .AddScoped<ICustomerProvider, CustomerProvider>()
    .AddScoped<IProductProvider, ProductProvider>()
    .AddScoped<IStockProvider, StockProvider>();

var provider = services.BuildServiceProvider();

var builder = OrderBuilder.Init(provider.GetRequiredService<ICustomerProvider>(),
    provider.GetRequiredService<IProductProvider>(),
    provider.GetRequiredService<IStockProvider>());

builder.SetCustomer(Guid.NewGuid().ToString());
builder.SetProduct(Guid.NewGuid().ToString());

var order = builder.Build();

void WriteData(dynamic data, string propertyName, bool isCustomer = true)
{
    var dataType = isCustomer ? nameof(order.Customer) : nameof(order.Product);
    Console.WriteLine($"{dataType} {propertyName} :  {data}");
}

WriteData(order.Customer.Id, nameof(order.Customer.Id));
WriteData(order.Customer.FirstName, nameof(order.Customer.FirstName));
WriteData(order.Customer.LastName, nameof(order.Customer.LastName));
WriteData(order.Customer.Email, nameof(order.Customer.Email));

foreach (var address in order.Customer.Addresses)
{
    WriteData(address.Id, nameof(address.Id));
    WriteData(address.Country, nameof(address.Country));
    WriteData(address.City, nameof(address.City));
    WriteData(address.County, nameof(address.County));
    WriteData(address.Street, nameof(address.Street));
    WriteData(address.ZipCode, nameof(address.ZipCode));
}

Console.WriteLine("**********");

WriteData(order.Product.Id, nameof(order.Product.Id), false);
WriteData(order.Product.Name, nameof(order.Product.Name), false);
WriteData(order.Product.Price, nameof(order.Product.Price), false);
WriteData(order.Product.Quantity, nameof(order.Product.Quantity), false);
WriteData(order.Product.Supplier.Id, $"{nameof(order.Product.Supplier)} {nameof(order.Product.Supplier.Id)}", false);
WriteData(order.Product.Supplier.Name, $"{nameof(order.Product.Supplier)} {nameof(order.Product.Supplier.Name)}",
    false);