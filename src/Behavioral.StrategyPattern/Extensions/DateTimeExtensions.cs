namespace Behavioral.StrategyPattern.Extensions;

public static class DateTimeExtensions
{
    public static string GetDayName(this DateTime dateTime, string location)
    {
        var culture = System.Globalization.CultureInfo.CreateSpecificCulture(location);
        return culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
    }
}