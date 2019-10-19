using Bogus;
using SchoolOccurrences.School.Domain.Commands.Occurrence;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Occurrence;
using System;
using Xunit;

namespace SchoolOccurrences.School.Tests.Commands.Occurrence
{
    public class CreateOccurrenceCommandTests
    {
        private Faker<CreateOccurrenceCommand> occurrence;

        [Fact]
        public void DeveRetornarCommandOcorrenciaValida()
        {
            occurrence = CreateOccurrenceCommandFaker.Gerar();

            var command = occurrence.Generate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void DeveRetornarCommandOcorrenciaDataInvalida()
        {
            occurrence = CreateOccurrenceCommandFaker.Gerar();

            var command = occurrence.Generate();

            command.Date = DateTime.Now.AddDays(2);
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandOcorrenciaCausaInvalida()
        {
            occurrence = CreateOccurrenceCommandFaker.Gerar();

            var command = occurrence.Generate();

            command.Cause = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandOcorrenciaCausaTamanhoMaximoInvalido()
        {
            occurrence = CreateOccurrenceCommandFaker.Gerar();

            var command = occurrence.Generate();

            int i = 0;

            while (i < 255)
            {
                command.Cause += "teste";
                i++;
            }

            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandOcorrenciaDescricaoInvalida()
        {
            occurrence = CreateOccurrenceCommandFaker.Gerar();

            var command = occurrence.Generate();

            command.Description = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandOcorrenciaDescricaoTamanhoMaximoInvalido()
        {
            occurrence = CreateOccurrenceCommandFaker.Gerar();

            var command = occurrence.Generate();

            int i = 0;

            while (i < 255)
            {
                command.Description += "teste";
                i++;
            }

            command.Validate();

            Assert.True(command.Invalid);
        }
    }
}
