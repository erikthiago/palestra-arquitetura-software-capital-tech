using Bogus;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Domain.Enums;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Entities
{
    public static class OccurrenceFaker
    {
        public static Faker<Occurrence> Gerar()
        {
            Faker<Occurrence> occurrence = new Faker<Occurrence>("pt_BR")
                .RuleFor(o => o.OccurrenceType, f => f.PickRandom<EOccurrenceType>())
                .RuleFor(o => o.Cause, f => f.Lorem.Word())
                .RuleFor(o => o.Description, f => f.Lorem.Paragraph())
                .RuleFor(o => o.OccurrenceStatus, f => f.PickRandom<EOccurrenceStatus>())
                .RuleFor(o => o.Date, f => f.Date.Recent());

            return occurrence;
        }
    }
}
