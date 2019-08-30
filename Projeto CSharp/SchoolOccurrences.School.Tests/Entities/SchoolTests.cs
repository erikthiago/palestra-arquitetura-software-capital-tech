using Bogus;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Entities;
using Xunit;

namespace SchoolOccurrences.School.Tests.Entities
{
    public class SchoolTests
    {
        private Faker<Domain.Entities.School> school;
        private Domain.Entities.School add;

        [Fact]
        public void DeveRetornarEscolaValida()
        {
            school = SchoolFaker.Gerar();

            var vO = school.Generate();

            add = new Domain.Entities.School(vO.Name, vO.Document, vO.Address, vO.Phone);

            Assert.True(add.Valid);
        }

        [Fact]
        public void DeveRetornarEscolaNomeInvalido()
        {
            school = SchoolFaker.Gerar();

            var vO = school.Generate();

            add = new Domain.Entities.School("", vO.Document, vO.Address, vO.Phone);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEscolaNomeTamanhoMinimoInvalido()
        {
            school = SchoolFaker.Gerar();

            var vO = school.Generate();

            add = new Domain.Entities.School("a", vO.Document, vO.Address, vO.Phone);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEscolaNomeTamanhoMaximoInvalido()
        {
            school = SchoolFaker.Gerar();

            var vO = school.Generate();

            int i = 0;
            string length = "";
            while (i < 50)
            {
                length += "teste";
                i++;
            }

            add = new Domain.Entities.School(vO.Name + length, vO.Document, vO.Address, vO.Phone);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEscolaTelefoneInvalido()
        {
            school = SchoolFaker.Gerar();

            var vO = school.Generate();

            add = new Domain.Entities.School(vO.Name, vO.Document, vO.Address, "");

            Assert.True(add.Invalid);
        }
    }
}
