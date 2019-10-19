using Bogus;
using SchoolOccurrences.School.Domain.Commands.Occurrence;
using System;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Occurrence
{
    public static class DeleteOccurrenceCommandFaker
    {
        public static Faker<DeleteOccurrenceCommand> Gerar()
        {
            Faker<DeleteOccurrenceCommand> deleteOccurrence = new Faker<DeleteOccurrenceCommand>("pt_BR")
                .RuleFor(del => del.Id, f => Guid.NewGuid());

            return deleteOccurrence;
        }
    }
}
