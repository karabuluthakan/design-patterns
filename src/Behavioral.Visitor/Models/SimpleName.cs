using Behavioral.Visitor.Abstract;

namespace Behavioral.Visitor.Models;

public record SimpleName(string FirstName, string LastName) : PersonalName
{
    public override T Accept<T>(IPersonalNameVisitor<T> visitor) => visitor.Visit(this);
}