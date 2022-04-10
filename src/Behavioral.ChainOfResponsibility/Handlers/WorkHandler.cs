namespace Behavioral.ChainOfResponsibility.Handlers;

public class WorkHandler : HandlerBase
{
    public override Resume Handle(Resume request)
    {
        var random = new Random();
        var work = new Faker<Work>()
            .RuleFor(x => x.Company, f => f.Person.Company.Name)
            .RuleFor(x => x.Department, f => f.PickRandom("IT", "Software Department", "E-Commerce"))
            .RuleFor(x => x.Title,
                f => f.PickRandom(".Net Developer", "React Developer", "Golang Developer", "Devops Engineer",
                    "Fullstack Developer"))
            .RuleFor(x => x.Start, f => f.Date.PastDateOnly())
            .RuleFor(x => x.End, f => f.Date.FutureDateOnly());

        var data = work.Generate(random.Next(2, 5));
        request.WorkExperinces ??= new List<Work>();
        request.WorkExperinces.AddRange(data);
        return request;
    }
}