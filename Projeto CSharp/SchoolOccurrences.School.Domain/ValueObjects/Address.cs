using Flunt.Validations;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using SchoolOccurrences.Shared.Commons.Validations;
using SchoolOccurrences.Shared.Commons.ValueObjects;

namespace SchoolOccurrences.School.Domain.ValueObjects
{
    //usado para OO e evitar muitas linhas de código
    public class Address : ValueObject
    {
        public Address()
        {

        }

        public Address(string street, int number, string neighborhood, string city, string stateName, string coutry, string zipCode, EStates abbr)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            StateName = stateName;
            Country = coutry;
            ZipCode = zipCode;
            Abbr = abbr;

            AddNotifications(new Contract()
               .Requires()
               //Validações sobre a rua
               .IsNotNullOrEmpty(Street, "Street", SharedMessages.InvalidStreet)
               .HasMinLen(Street, 3, "Street", string.Format(SharedMessages.MinLength, "Rua", 3))
               .HasMaxLen(Street, 50, "Street", string.Format(SharedMessages.MaxLength, "Rua", 50))
               //Validações sobre o bairro
               .IsNotNullOrEmpty(Neighborhood, "Neighborhood", SharedMessages.InvalidNeighborhood)
               .HasMinLen(Neighborhood, 3, "Neighborhood", string.Format(SharedMessages.MinLength, "Bairro", 3))
               .HasMaxLen(Neighborhood, 50, "Neighborhood", string.Format(SharedMessages.MaxLength, "Bairro", 50))
               //validações sobre a cidade
               .IsNotNullOrEmpty(City, "City", SharedMessages.InvalidNeighborhood)
               .HasMinLen(City, 3, "City", string.Format(SharedMessages.MinLength, "Cidade", 3))
               .HasMaxLen(City, 50, "City", string.Format(SharedMessages.MaxLength, "Cidade", 50))
               //validações do país
               .IsNotNullOrEmpty(Country, "Coutry", SharedMessages.InvalidNeighborhood)
               .HasMinLen(Country, 3, "Coutry", string.Format(SharedMessages.MinLength, "País", 3))
               .HasMaxLen(Country, 50, "Coutry", string.Format(SharedMessages.MaxLength, "País", 50))
               //validações do CEP
               .IsNotNullOrEmpty(ZipCode, "ZipCode", SharedMessages.InvalidNeighborhood)
               .IsTrue(CepValidation.ValidaCEP(ZipCode), "ZipCode", SharedMessages.InvalidZipCode)
               //Validações do estado
               .IsNotNullOrEmpty(StateName, "Name", SharedMessages.InvalidState)
               .HasMinLen(StateName, 3, "Name", string.Format(SharedMessages.MinLength, "Nome do Estado", 3))
               .HasMaxLen(StateName, 50, "Name", string.Format(SharedMessages.MaxLength, "Nome do Estado", 50))
               );
        }

        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string StateName { get; private set; }
        public EStates Abbr { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}
