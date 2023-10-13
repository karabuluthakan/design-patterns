using Behavioral.Visitor.Abstract;

namespace Behavioral.Visitor.Models;

public class Publication
{
    public string Title { get; private init; }
    public IEnumerable<PersonalName> Authors => this.AuthorList;
    public List<PersonalName> AuthorList { get; set; }

    public Publication(string title, params PersonalName[] authors)
    {
        Title = title;
        AuthorList = authors.ToList();
    }

    public string ToString(IPersonalNameVisitor<string> formatter) => this.AuthorList.Count == 0
        ? Title
        : $"{string.Join(", ", AuthorList.Select(x => x.Accept(formatter)))}, {Title}";

    public override string ToString() =>
        this.AuthorList.Count == 0 ? Title : $"{Title} by {string.Join(", ", Authors)}";
}