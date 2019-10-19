using Bogus;
using SchoolOccurrences.School.Domain.Commands.Student;
using System;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Parent
{
    public static class DeleteStudentCommandFaker
    {
        public static Faker<DeleteStudentCommand> Gerar()
        {
            Faker<DeleteStudentCommand> deleteStudent = new Faker<DeleteStudentCommand>("pt_BR")
                .RuleFor(del => del.Id, f => Guid.NewGuid());

            return deleteStudent;
        }
    }
}
