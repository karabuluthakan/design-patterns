namespace Behavioral.StrategyPattern.Extensions;

public static class HttpContextAccessorExtensions
{
    public static string GetLocation(this IHttpContextAccessor httpContextAccessor)
    {
        httpContextAccessor!.HttpContext!.Request.Headers.TryGetValue(DataProvider.HeaderValue, out var value);
        return value.FirstOrDefault() ?? DataProvider.HeaderValueTR;
    }
}