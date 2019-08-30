using Bogus;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Tests.Helpers.Fakers.ValueObjects;
using Xunit;

namespace SchoolOccurrences.School.Tests.Entities
{
    public class ParentTests
    {
        private Faker<Parent> parent;
        private Parent add;

        [Fact]
        public void DeveRetornarParentesValidos()
        {
            parent = ParentFaker.Gerar();

            var vO = parent.Generate();

            add = new Parent(vO.ResponsibleName, vO.ResponsibleDocument, vO.EFamilyType, vO.Email, vO.Telephone);

            Assert.True(add.Valid);
        }

        [Fact]
        public void DeveRetornarParentesNomeInvalido()
        {
            parent = ParentFaker.Gerar();

            var vO = parent.Generate();

            add = new Parent("", vO.ResponsibleDocument, vO.EFamilyType, vO.Email, vO.Telephone);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarParentesNomeTamanhoMinimoInvalido()
        {
            parent = ParentFaker.Gerar();

            var vO = parent.Generate();

            add = new Parent("a", vO.ResponsibleDocument, vO.EFamilyType, vO.Email, vO.Telephone);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarParentesNameTamanhoMaximoInvalido()
        {
            parent = ParentFaker.Gerar();

            var vO = parent.Generate();

            int i = 0;
            string length = "";

            while (i < 100)
            {
                length += "teste";
                i++;
            }

            add = new Parent(vO.ResponsibleName + length, vO.ResponsibleDocument, vO.EFamilyType, vO.Email, vO.Telephone);

            Assert.True(add.Invalid);
        }
    }
}
