using Bogus;
using SchoolOccurrences.School.Domain.Commands.Student;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Enums;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Student
{
    public static class CreateStudentCommandFaker
    {
        public static Faker<CreateStudentCommand> Gerar()
        {
            Faker<CreateStudentCommand> createStudent = new Faker<CreateStudentCommand>("pt_BR")
                .RuleFor(cs => cs.FirstName, f => f.Name.FullName())
                .RuleFor(cs => cs.LastName, f => f.Name.LastName())
                .RuleFor(cs => cs.Street, f => f.Address.StreetName())
                .RuleFor(cs => cs.Number, f => f.Random.Int(1, 111))
                .RuleFor(cs => cs.Neighborhood, f => f.Address.StreetAddress())
                .RuleFor(cs => cs.City, f => f.Address.City())
                .RuleFor(cs => cs.StateName, f => f.Address.State())
                .RuleFor(cs => cs.Abbr, f => f.PickRandom<EStates>())
                .RuleFor(cs => cs.Coutry, f => f.Address.County())
                .RuleFor(cs => cs.ZipCode, f => f.Address.ZipCode("#####-###"))
                .RuleFor(cs => cs.BirthDate, f => f.Date.Recent())
                .RuleFor(cs => cs.ETypeOfEducation, f => f.PickRandom<ETypeOfEducation>())
                .RuleFor(cs => cs.AcademicYear, f => f.Date.Recent())
                .RuleFor(cs => cs.Number, f => f.Random.Int(1, 9))
                .RuleFor(cs => cs.Grade, f => f.Random.String(1))
                .RuleFor(cs => cs.Shifts, f => f.PickRandom<EShifts>())
                .RuleFor(cs => cs.CalledNumber, f => f.Random.Int(1, 30))
                .RuleFor(cs => cs.Note, f => f.Lorem.Paragraphs(1))
                .RuleFor(cs => cs.Serie, f => f.Random.Int(1, 1));

            return createStudent;
        }
    }
}
