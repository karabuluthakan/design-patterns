namespace Behavioral.ChainOfResponsibility.Handlers;

public class EducationHandler : HandlerBase
{
    public override Resume Handle(Resume request)
    {
        var fistDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-10));
        var secondDate = DateOnly.FromDateTime(DateTime.Now).AddYears(-5);
        var random = new Random();
        var education = new Faker<Education>()
            .RuleFor(x => x.School,
                f => f.PickRandom("Andromeda University", "Artemis Institute of Technology",
                    "Awake My Jedi Mindschool", "Advanced Brain Studies", "Stargate Academy",
                    "Academic Center for Sorcery", "Dragon’s Cove Intermediate School", "Amber School for Wizardry",
                    "Polymorphic College for Alienating Species"))
            .RuleFor(x => x.Faculty,
                f => f.PickRandom("Institute of Science", "Faculty of Computer Science",
                    "Faculty of Architecture and Engineering"))
            .RuleFor(x => x.Department,
                f => f.PickRandom("Computer Science", "Electrical Engineer", "Industrial Engineer",
                    "Mathematics Engineer", "Chemical Engineer", "Physics Engineer", "Civil Engineer", "Architect"))
            .RuleFor(x => x.Start, f => f.Date.BetweenDateOnly(fistDate, secondDate))
            .RuleFor(x => x.End, f => f.Date.BetweenDateOnly(fistDate.AddYears(4), secondDate.AddYears(4)));

        var data = education.Generate(random.Next(2, 4));
        request.Educations ??= new List<Education>();
        request.Educations.AddRange(data);
        return request;
    }
}