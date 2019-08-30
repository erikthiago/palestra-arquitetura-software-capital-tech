using Bogus;
using SchoolOccurrences.School.Domain.Commands.Occurrence;
using SchoolOccurrences.School.Domain.Enums;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Occurrence
{
    public static class CreateOccurrenceCommandFaker
    {
        public static Faker<CreateOccurrenceCommand> Gerar()
        {
            Faker<CreateOccurrenceCommand> createOccurrence = new Faker<CreateOccurrenceCommand>("pt_BR")
                .RuleFor(co => co.OccurrenceType, f => f.PickRandom<EOccurrenceType>())
                .RuleFor(co => co.Cause, f => f.Lorem.Word())
                .RuleFor(co => co.Description, f => f.Lorem.Paragraph())
                .RuleFor(co => co.OccurrenceStatus, f => f.PickRandom<EOccurrenceStatus>())
                .RuleFor(co => co.Date, f => f.Date.Recent());

            return createOccurrence;
        }
    }
}
