using Bogus;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.School.Tests.Helpers.Fakers.ValueObjects;
using Xunit;

namespace SchoolOccurrences.School.Tests.ValueObjects
{
    public class AddressTests
    {
        private Faker<Address> address;
        private Address add;

        [Fact]
        public void DeveRetornarEnderecoValido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, vO.City, vO.StateName, vO.Country, vO.ZipCode, vO.Abbr);

            Assert.True(add.Valid);
        }

        [Fact]
        public void DeveRetornarEnderecoRuaInvalida()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            add = new Address("", vO.Number, vO.Neighborhood, vO.City, vO.StateName, vO.Country, vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoRuaTamanhoInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            int i = 0;
            string length = "";
            while (i < 50)
            {
                length += "teste";
                i++;
            }

            add = new Address(vO.Street + length, vO.Number, vO.Neighborhood, vO.City, vO.StateName, vO.Country, vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoBairroInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            add = new Address(vO.Street, vO.Number, "", vO.City, vO.StateName, vO.Country, vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoBairroTamanhoInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            int i = 0;
            string length = "";
            while (i < 50)
            {
                length += "teste";
                i++;
            }

            add = new Address(vO.Street, vO.Number, vO.Neighborhood + length, vO.City, vO.StateName, vO.Country, vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoCidadeInvalida()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, "", vO.StateName, vO.Country, vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoCidadeTamanhoInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            int i = 0;
            string length = "";
            while (i < 50)
            {
                length += "teste";
                i++;
            }

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, vO.City + length, vO.StateName, vO.Country, vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoPaisInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, vO.City, vO.StateName, "", vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoPaisTamanhoInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            int i = 0;
            string length = "";
            while (i < 50)
            {
                length += "teste";
                i++;
            }

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, vO.City, vO.StateName, vO.Country + length, vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoCepInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, vO.City, vO.StateName, vO.Country, "", vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoCepFormatoInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, vO.City, vO.StateName, vO.Country, "66.777000", vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEstadoNomeInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, vO.City, "", vO.Country, vO.ZipCode, vO.Abbr);

            Assert.True(add.Invalid);
        }

        [Fact]
        public void DeveRetornarEnderecoEstadoTamanhoInvalido()
        {
            address = AddressFaker.Gerar();

            var vO = address.Generate();


            int i = 0;
            string length = "";
            while (i < 50)
            {
                length += "teste";
                i++;
            }

            add = new Address(vO.Street, vO.Number, vO.Neighborhood, vO.City, vO.StateName + length, vO.Country, vO.ZipCode, vO.Abbr);


            Assert.True(add.Invalid);
        }
    }
}
