namespace Structural.Decorator.Utilities;

public class DataProvider
{
    public static readonly string[] EnglishWeatherSummaries =
        { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    public static readonly string[] GermanWeatherSummaries =
        { "Gefrierend", "Belebend", "Kalt", "Kühl", "Mild", "Warm", "Balsam", "Heiß", "Schwül", "Sengend" };

    public static readonly string[] TurkishWeatherSummaries =
        { "Dondurucu", "Temiz", "Serin", "Soğuk", "Hafif", "Ilık", "Sıcak", "Bunaltıcı", "Kavurucu" };

    public const string HeaderValue = "Location"; 
    public const string HeaderValueTR = "tr";
    public const string HeaderValueEN = "en";
    public const string HeaderValueDE = "de";
}