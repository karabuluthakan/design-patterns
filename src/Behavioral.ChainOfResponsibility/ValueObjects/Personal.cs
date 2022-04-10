namespace Behavioral.ChainOfResponsibility.ValueObjects;

public class Personal : IValueObject
{
    public string FistName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}