namespace Behavioral.ChainOfResponsibility.ValueObjects;

public class Work : IValueObject
{
    public string Company { get; set; }
    public string Department { get; set; }
    public string Title { get; set; }
    public DateOnly Start { get; set; }
    public DateOnly? End { get; set; }
}