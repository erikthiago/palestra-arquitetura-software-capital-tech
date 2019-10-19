using Bogus;
using SchoolOccurrences.School.Domain.Commands.Student;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Parent;
using System;
using Xunit;

namespace SchoolOccurrences.School.Tests.Commands.Student
{
    public class DeleteStudentCommandTests
    {
        private Faker<DeleteStudentCommand> student;

        [Fact]
        public void DeveRetornarCommandResponsavelValido()
        {
            student = DeleteStudentCommandFaker.Gerar();

            var command = student.Generate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void DeveRetornarCommandResponsavelGuidInvalido()
        {
            student = DeleteStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.Id = Guid.Empty;

            command.Validate();

            Assert.True(command.Invalid);
        }
    }
}
