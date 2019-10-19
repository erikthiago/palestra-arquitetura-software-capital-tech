using Bogus;
using SchoolOccurrences.School.Domain.Commands.Parent;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Parent;
using Xunit;

namespace SchoolOccurrences.School.Tests.Commands.Parent
{
    public class CreateParentCommandTests
    {
        private Faker<CreateParentCommand> parent;

        [Fact]
        public void DeveRetornarCommandResponsavelValido()
        {
            parent = CreateParentCommandFaker.Gerar();

            var command = parent.Generate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void DeveRetornarCommandNomeResponsavelInvalido()
        {
            parent = CreateParentCommandFaker.Gerar();

            var command = parent.Generate();

            command.ResponsibleName = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeResponsavelTamanhoMaximoInvalido()
        {
            parent = CreateParentCommandFaker.Gerar();

            var command = parent.Generate();

            int i = 0;
            while (i < 100)
            {
                command.ResponsibleName += "tes";
                i++;
            }

            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeResponsavelTamanhoMinimoInvalido()
        {
            parent = CreateParentCommandFaker.Gerar();

            var command = parent.Generate();

            command.ResponsibleName = "t";

            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeResponsavelEmailInvalido()
        {
            parent = CreateParentCommandFaker.Gerar();

            var command = parent.Generate();

            command.AddressEmail = "@e";

            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeResponsavelDocumentoInvalido()
        {
            parent = CreateParentCommandFaker.Gerar();

            var command = parent.Generate();

            command.DocumentNumber = "00998";

            command.Validate();

            Assert.True(command.Invalid);
        }
    }
}
