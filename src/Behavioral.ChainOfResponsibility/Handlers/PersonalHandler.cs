namespace Behavioral.ChainOfResponsibility.Handlers;

public class PersonalHandler : HandlerBase
{
    public override Resume Handle(Resume request)
    {
        var data = new Faker<Personal>()
            .RuleFor(x => x.FistName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Email, f => f.Person.Email.ToLowerInvariant())
            .RuleFor(x => x.Phone, f => f.Person.Phone)
            .Generate();

        request.PersonalInformation ??= new Personal();
        request.PersonalInformation = data;
        return request;
    }
}