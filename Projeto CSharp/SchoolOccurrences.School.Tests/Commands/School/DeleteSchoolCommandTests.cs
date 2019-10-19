using Bogus;
using SchoolOccurrences.School.Domain.Commands.School;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.School;
using System;
using Xunit;

namespace SchoolOccurrences.School.Tests.Commands.School
{
    public class DeleteSchoolCommandTests
    {
        private Faker<DeleteSchoolCommand> school;

        [Fact]
        public void DeveRetornarCommandResponsavelValido()
        {
            school = DeleteSchoolCommandFaker.Gerar();

            var command = school.Generate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void DeveRetornarCommandResponsavelGuidInvalido()
        {
            school = DeleteSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.Id = Guid.Empty;

            command.Validate();

            Assert.True(command.Invalid);
        }
    }
}
