using Bogus;
using SchoolOccurrences.School.Domain.ValueObjects;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.ValueObjects
{
    public static class NameFaker
    {
        public static Faker<Name> Gerar()
        {
            Faker<Name> name = new Faker<Name>("pt_BR")
                .RuleFor(n => n.FirstName, f => f.Name.FirstName())
                .RuleFor(n => n.LastName, f => f.Name.LastName());

            return name;
        }
    }
}
