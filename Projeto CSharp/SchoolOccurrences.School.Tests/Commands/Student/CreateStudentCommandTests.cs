using Bogus;
using SchoolOccurrences.School.Domain.Commands.Student;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Student;
using Xunit;

namespace studentOccurrences.student.Tests.Commands.Student
{
    public class CreateStudentCommandTests
    {
        private Faker<CreateStudentCommand> student;

        [Fact]
        public void DeveRetornarCommandAlunoValido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void DeveRetornarCommandSerieAlunoInvalida()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.Serie = 0;
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandTurmaAlunoInvalida()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.Grade = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandTurmaAlunoTamanhoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.Grade = "aaa";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandPrimeiroNomeAlunoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.FirstName = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandPrimeiroNomeAlunoTamanhoMinimoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.FirstName = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandPrimeiroNomeAlunoTamanhoMaximoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            int i = 0;

            while (i < 40)
            {
                command.FirstName = "a";
                i++;
            }
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandSobreNomeAlunoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.LastName = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandSobreNomeAlunoTamanhoMinimoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.LastName = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandSobreNomeAlunoTamanhoMaximoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            int i = 0;

            while (i < 40)
            {
                command.LastName = "a";
                i++;
            }
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandRuaAlunoInvalida()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.Street = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeRuaTamanhoMinimoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.Street = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandRuaAlunoTamanhoMaximoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

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
        public void DeveRetornarCommandBairroAlunoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.Neighborhood = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandBairroAlunoTamanhoMinimoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.Neighborhood = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandBairroAlunoTamanhoMaximoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

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
        public void DeveRetornarCommandCidadeAlunoInvalida()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.City = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCidadeAlunoTamanhoMinimoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.City = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCidadeAlunoTamanhoMaximoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

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
        public void DeveRetornarCommandNomeEstadoAlunoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.StateName = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeEstadoAlunoTamanhoMinimoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.StateName = "a";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandNomeEstadoAlunoTamanhoMaximoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            int i = 0;

            while (i < 50)
            {
                command.StateName += "a";
                i++;
            }
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCepAlunoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.ZipCode = "";
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void DeveRetornarCommandCepFormatoAlunoInvalido()
        {
            student = CreateStudentCommandFaker.Gerar();

            var command = student.Generate();

            command.ZipCode = "00.0000000";
            command.Validate();

            Assert.True(command.Invalid);
        }
    }
}
