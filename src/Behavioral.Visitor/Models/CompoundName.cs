using Behavioral.Visitor.Abstract;

namespace Behavioral.Visitor.Models;

public record CompoundName(string FirstName, string MiddleNames, string LastName) : PersonalName
{
    public override T Accept<T>(IPersonalNameVisitor<T> visitor) => visitor.Visit(this);
}