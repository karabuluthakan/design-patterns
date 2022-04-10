// See https://aka.ms/new-console-template for more information

var services = new ServiceCollection()
    .AddScoped<ICustomerProvider, CustomerProvider>()
    .AddScoped<IProductProvider, ProductProvider>()
    .AddScoped<IStockProvider, StockProvider>()
    .AddScoped<ICampaignProvider, CampaignProvider>()
    .AddScoped<IBasketFacade, BasketFacade>();

var customerId = Guid.NewGuid().ToString("N");
var productId = Guid.NewGuid().ToString("N");
var random = new Random();
var quantity = random.Next(1, 5);
Console.WriteLine(quantity);
var request = new BasketRequest(customerId, productId, quantity);

var facade = services.BuildServiceProvider().GetRequiredService<IBasketFacade>();
var basket = await facade.GetBasketAsync(request);

Console.WriteLine($"Customer Id : {basket.Customer.Id}");
Console.WriteLine($"Customer FistName : {basket.Customer.FistName}");
Console.WriteLine($"Customer LastName : {basket.Customer.LastName}");
Console.WriteLine($"Customer City : {basket.Customer.City}");
Console.WriteLine($"Customer Street : {basket.Customer.Street}");
Console.WriteLine($"Customer ZipCode : {basket.Customer.ZipCode}");
Console.WriteLine($"Product Id : {basket.Product.Id}");
Console.WriteLine($"Product Name : {basket.Product.Name}");
Console.WriteLine($"Product Price : {basket.Product.Price}");
Console.WriteLine($"Quantity : {basket.Quantity}");