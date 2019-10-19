using Bogus;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.School.Tests.Helpers.Fakers.ValueObjects;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Entities
{
    public static class StudentFaker
    {
        public static Faker<Student> Gerar()
        {
            Faker<Student> student = new Faker<Student>("pt_BR")
                .RuleFor(s => s.Name, NameFaker.Gerar())
                .RuleFor(s => s.Parents, ParentFaker.Gerar().Generate(2))
                .RuleFor(s => s.Address, AddressFaker.Gerar())
                .RuleFor(s => s.BirthDate, f => f.Date.Soon())
                .RuleFor(s => s.ETypeOfEducation, f => f.PickRandom<ETypeOfEducation>())
                .RuleFor(s => s.AcademicYear, f => f.Date.Soon())
                .RuleFor(s => s.Serie, f => f.Random.Int(1))
                .RuleFor(s => s.Grade, f => f.Random.String(1))
                .RuleFor(s => s.Serie, f => f.Random.Int(1))
                .RuleFor(s => s.Shifts, f => f.PickRandom<EShifts>())
                .RuleFor(s => s.CalledNumber, f => f.Random.Int(1,30))
                .RuleFor(s => s.Note, f => f.Lorem.Paragraphs(1))
                .RuleFor(s => s.School, SchoolFaker.Gerar())
                .RuleFor(s => s.Occurrences, OccurrenceFaker.Gerar().Generate(1));

            return student;
        }
    }
}
