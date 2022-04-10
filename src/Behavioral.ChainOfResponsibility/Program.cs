// See https://aka.ms/new-console-template for more information

var resume = new Resume();
var personalHandler = new PersonalHandler();
var workHandler = new WorkHandler();
var educationHandler = new EducationHandler();
personalHandler.Handle(resume);
personalHandler.SetNext(workHandler);
workHandler.Handle(resume);
workHandler.SetNext(educationHandler);
workHandler.Handle(resume);
educationHandler.Handle(resume);

Console.WriteLine($"FistName : {resume.PersonalInformation.FistName}");
Console.WriteLine($"LastName : {resume.PersonalInformation.LastName}");
Console.WriteLine($"Email : {resume.PersonalInformation.Email}");
Console.WriteLine($"Phone : {resume.PersonalInformation.Phone}");

Console.WriteLine("-----------------------");

for (var i = 0; i < resume.WorkExperinces.Count; i++)
{
    var data = resume.WorkExperinces[i];
    Console.WriteLine($"{i + 1}. Company : {data.Company}");
    Console.WriteLine($"{i + 1}. Department : {data.Department}");
    Console.WriteLine($"{i + 1}. Title : {data.Title}");
    Console.WriteLine($"{i + 1}. Start : {data.Start}");
    Console.WriteLine($"{i + 1}. End : {data.End}");
}

Console.WriteLine("-----------------------");

for (var i = 0; i < resume.Educations.Count; i++)
{
    var data = resume.Educations[i];
    Console.WriteLine($"{i + 1}. School : {data.School}");
    Console.WriteLine($"{i + 1}. Faculty : {data.Faculty}");
    Console.WriteLine($"{i + 1}. Department : {data.Department}");
    Console.WriteLine($"{i + 1}. Start : {data.Start}");
    Console.WriteLine($"{i + 1}. End : {data.End}");
}