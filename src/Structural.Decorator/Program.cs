const string AllowCorsPolicy = nameof(AllowCorsPolicy);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowCorsPolicy,
        b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            .SetPreflightMaxAge(TimeSpan.FromSeconds(86400)).WithExposedHeaders("WWW-Authenticate"));
});

builder.Services.AddSingleton<IRepository, FakeWeatherForecastRepository>();

builder.Services.AddSingleton<ICacheProvider>(_ =>
{
    var connectionString = Guard.Against.NullOrEmpty(builder.Configuration.GetConnectionString("Redis"));
    return new RedisCacheProvider(connectionString);
});

builder.Services.AddScoped<IDecorator>(sp =>
{
    var repository = sp.GetRequiredService<IRepository>();
    var cache = sp.GetRequiredService<ICacheProvider>();
    return new CacheDecorator(cache, repository);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowCorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();