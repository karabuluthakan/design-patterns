namespace Behavioral.ChainOfResponsibility.Entities;

public class Resume : IEntity
{
    public Personal PersonalInformation { get; set; }
    public List<Work> WorkExperinces { get; set; }
    public List<Education> Educations { get; set; }
}