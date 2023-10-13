using Behavioral.Visitor.Abstract;
using Behavioral.Visitor.Models;

namespace Behavioral.Visitor.Formatters;

public class CommonNameFormatter : IPersonalNameVisitor<string>
{
    public string Visit(SimpleName name) => $"{name.FirstName} {name.LastName}";
    public string Visit(Mononym name) => name.Name;
    public string Visit(CompoundName name) => $"{name.FirstName} {name.LastName}";
}