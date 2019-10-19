using Bogus;
using SchoolOccurrences.School.Domain.Commands.Parent;
using System;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Parent
{
    public static class DeleteParentCommandFaker
    {
        public static Faker<DeleteParentCommand> Gerar()
        {
            Faker<DeleteParentCommand> deleteParent = new Faker<DeleteParentCommand>("pt_BR")
                .RuleFor(del => del.Id, f => Guid.NewGuid());

            return deleteParent;
        }
    }
}
