using Bogus;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.School.Tests.Helpers.Fakers.ValueObjects;
using Xunit;

namespace SchoolOccurrences.School.Tests.ValueObjects
{
    public class NameTests
    {
        private Faker<Name> name;
        private Name add;
        [Fact]
        public void DeveRetornarNomeValido()
        {
            name = NameFaker.Gerar();

            var vO = name.Generate();

            add = new Name(vO.FirstName, vO.LastName);

            Assert.True(add.Valid);
        }

        [Fact]
        public void DeveRetornarPrimeiroNomeInvalida()
        {
            name = NameFaker.Gerar();

            var vO = name.Generate();

            add = new Name("", vO.LastName);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarPrimeiroNomeTamanhoInvalido()
        {
            name = NameFaker.Gerar();

            var vO = name.Generate();

            int i = 0;
            string length = "";
            while (i < 40)
            {
                length += "teste";
                i++;
            }

            add = new Name(vO.FirstName + length, vO.LastName);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarSobreNomeInvalida()
        {
            name = NameFaker.Gerar();

            var vO = name.Generate();

            add = new Name(vO.FirstName, "");

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornaSobreNomeTamanhoInvalido()
        {
            name = NameFaker.Gerar();

            var vO = name.Generate();

            int i = 0;
            string length = "";
            while (i < 40)
            {
                length += "teste";
                i++;
            }

            add = new Name(vO.FirstName, vO.LastName + length);

            Assert.True(add.Invalid);
        }
    }
}
