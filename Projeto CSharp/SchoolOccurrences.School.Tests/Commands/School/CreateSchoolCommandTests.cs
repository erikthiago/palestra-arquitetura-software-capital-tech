using Bogus;
using SchoolOccurrences.School.Domain.Commands.School;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.School;
using Xunit;

namespace SchoolOccurrences.School.Tests.Commands.School
{
    public class CreateSchoolCommandTests
    {
        private Faker<CreateSchoolCommand> school;

        [Fact]
        public void DeveRetornarCommandEscolaValida()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void DeveRetornarCommandNomeEscolaInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.Name = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeEscolaTamanhoMinimoInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.Name = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeEscolaTamanhoMaximoInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            int i = 0;

            while (i < 40)
            {
                command.Name += "a";
                i++;
            }
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandRuaEscolaInvalida()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.Street = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeRuaTamanhoMinimoInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.Street = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandRuaEscolaTamanhoMaximoInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            int i = 0;

            while (i < 40)
            {
                command.Street += "a";
                i++;
            }
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandBairroEscolaInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.Neighborhood = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandBairroEscolaTamanhoMinimoInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.Neighborhood = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandBairroEscolaTamanhoMaximoInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            int i = 0;

            while (i < 40)
            {
                command.Neighborhood += "a";
                i++;
            }
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCidadeEscolaInvalida()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.City = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCidadeEscolaTamanhoMinimoInvalida()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.City = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCidadeEscolaTamanhoMaximoInvalida()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            int i = 0;

            while (i < 40)
            {
                command.City += "a";
                i++;
            }
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeEstadoEscolaInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.StateName = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeEstadoEscolaTamanhoMinimoInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.StateName = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeEstadoEscolaTamanhoMaximoInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            int i = 0;

            while (i < 40)
            {
                command.StateName += "a";
                i++;
            }
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCepEscolaInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.ZipCode = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCepFormatoEscolaInvalido()
        {
            school = CreateSchoolCommandFaker.Gerar();

            var command = school.Generate();

            command.ZipCode = "00.0000000";
            command.Validate();

            Assert.True(command.Invalid);
        }
    }
}
