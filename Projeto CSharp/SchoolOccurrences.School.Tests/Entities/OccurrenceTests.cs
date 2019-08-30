using Bogus;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Entities;
using Xunit;

namespace SchoolOccurrences.School.Tests.Entities
{
    public class OccurrenceTests
    {
        private Faker<Occurrence> occurrence;
        private Occurrence add;

        [Fact]
        public void DeveRetornarOcorrenciaValida()
        {
            occurrence = OccurrenceFaker.Gerar();

            var vO = occurrence.Generate();

            add = new Occurrence(vO.OccurrenceType, vO.Cause, vO.Description, vO.OccurrenceStatus, vO.Date);

            Assert.True(add.Valid);
        }

        [Fact]
        public void DeveRetornarOcorrenciaCausaInvalida()
        {
            occurrence = OccurrenceFaker.Gerar();

            var vO = occurrence.Generate();

            add = new Occurrence(vO.OccurrenceType, "", vO.Description, vO.OccurrenceStatus, vO.Date);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarOcorrenciaCausaTamanhoInvalida()
        {
            occurrence = OccurrenceFaker.Gerar();

            var vO = occurrence.Generate();

            int i = 0;
            string length = "";
            while (i < 255)
            {
                length += "teste";
                i++;
            }

            add = new Occurrence(vO.OccurrenceType, vO.Cause + length, vO.Description, vO.OccurrenceStatus, vO.Date);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarOcorrenciaDescricaoInvalida()
        {
            occurrence = OccurrenceFaker.Gerar();

            var vO = occurrence.Generate();

            add = new Occurrence(vO.OccurrenceType, vO.Cause, "", vO.OccurrenceStatus, vO.Date);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarOcorrenciaDescricaoTamanhoInvalida()
        {
            occurrence = OccurrenceFaker.Gerar();

            var vO = occurrence.Generate();

            int i = 0;
            string length = "";
            while (i < 255)
            {
                length += "teste";
                i++;
            }

            add = new Occurrence(vO.OccurrenceType, vO.Cause, vO.Description + length, vO.OccurrenceStatus, vO.Date);

            Assert.True(add.Invalid);
        }
    }
}
