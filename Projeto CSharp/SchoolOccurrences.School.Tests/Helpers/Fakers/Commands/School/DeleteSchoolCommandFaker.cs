using Bogus;
using SchoolOccurrences.School.Domain.Commands.School;
using System;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.School
{
    public static class DeleteSchoolCommandFaker
    {
        public static Faker<DeleteSchoolCommand> Gerar()
        {
            Faker<DeleteSchoolCommand> deleteSchool = new Faker<DeleteSchoolCommand>("pt_BR")
                .RuleFor(del => del.Id, f => Guid.NewGuid());

            return deleteSchool;
        }
    }
}
