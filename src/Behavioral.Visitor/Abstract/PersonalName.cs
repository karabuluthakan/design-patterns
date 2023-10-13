namespace Behavioral.Visitor.Abstract;

public abstract record PersonalName()
{
    public abstract T Accept<T>(IPersonalNameVisitor<T> visitor);
}