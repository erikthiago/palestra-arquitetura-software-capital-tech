using Bogus;
using SchoolOccurrences.School.Domain.Commands.Occurrence;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Occurrence;
using System;
using Xunit;

namespace SchoolOccurrences.School.Tests.Commands.Occurrence
{
    public class DeleteOccurrenceCommandTests
    {
        private Faker<DeleteOccurrenceCommand> occurrence;

        [Fact]
        public void DeveRetornarCommandOcorrenciaValido()
        {
            occurrence = DeleteOccurrenceCommandFaker.Gerar();

            var command = occurrence.Generate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void DeveRetornarCommandOcorrenciaGuidInvalido()
        {
            occurrence = DeleteOccurrenceCommandFaker.Gerar();

            var command = occurrence.Generate();

            command.Id = Guid.Empty;

            command.Validate();

            Assert.True(command.Invalid);
        }
    }
}
