using Behavioral.Visitor.Abstract;

namespace Behavioral.Visitor.Models;

public record Mononym(string Name) : PersonalName
{
    public override T Accept<T>(IPersonalNameVisitor<T> visitor) => visitor.Visit(this);
}