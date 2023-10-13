using Behavioral.Visitor.Abstract;
using Behavioral.Visitor.Formatters;
using Behavioral.Visitor.Models;

Publication[] publications =
{
    new("Aladdin and the Magic Lamp"),
    new("The Essays", new Mononym("Montaigne")),
    new("Machine Learning", new SimpleName("Ethem", "Alpaydın")),
    new("Data Science", new SimpleName("John", "Kelleher"), new SimpleName("Brendan", "Tierney"))
};

void Print(IEnumerable<Publication> publications, IPersonalNameVisitor<string> formatter)
{
    foreach (var publication in publications)
    {
        Console.WriteLine(publication.ToString(formatter));
    }

    Console.WriteLine(new string('-', 80));
    Console.WriteLine();
}

Print(publications, new CommonNameFormatter());
Print(publications, new AcademicNameFormatter());