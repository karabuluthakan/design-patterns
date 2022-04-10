namespace Behavioral.ChainOfResponsibility.ValueObjects;

public class Education : IValueObject
{
    public string School { get; set; }
    public string Faculty { get; set; }
    public string Department { get; set; }
    public DateOnly Start { get; set; }
    public DateOnly? End { get; set; }
}