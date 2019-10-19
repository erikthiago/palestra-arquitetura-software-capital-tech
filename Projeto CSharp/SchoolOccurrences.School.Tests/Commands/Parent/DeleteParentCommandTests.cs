using Bogus;
using SchoolOccurrences.School.Domain.Commands.Parent;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Parent;
using System;
using Xunit;

namespace SchoolOccurrences.School.Tests.Commands.Parent
{
    public class DeleteParentCommandTests
    {
        private Faker<DeleteParentCommand> parent;

        [Fact]
        public void DeveRetornarCommandResponsavelValido()
        {
            parent = DeleteParentCommandFaker.Gerar();

            var command = parent.Generate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void DeveRetornarCommandResponsavelGuidInvalido()
        {
            parent = DeleteParentCommandFaker.Gerar();

            var command = parent.Generate();

            command.Id = Guid.Empty;

            command.Validate();

            Assert.True(command.Invalid);
        }
    }
}
