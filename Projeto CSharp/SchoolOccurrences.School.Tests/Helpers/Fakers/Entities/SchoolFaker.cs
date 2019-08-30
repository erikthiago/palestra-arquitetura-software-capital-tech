using Bogus;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.School.Tests.Helpers.Fakers.ValueObjects;
using SchoolOccurrences.Shared.Commons.Enums;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Entities
{
    public static class SchoolFaker
    {
        public static Faker<Domain.Entities.School> Gerar()
        {
            Faker<Domain.Entities.School> school = new Faker<Domain.Entities.School>("pt_BR")
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.Document, f => JuridiqueDocument())
                .RuleFor(s => s.Address, AddressFaker.Gerar())
                .RuleFor(s => s.Phone, f => f.Phone.PhoneNumberFormat());

            return school;
        }

        private static Document JuridiqueDocument()
        {
            return new Document(Bogus.Extensions.Brazil.ExtensionsForBrazil.Cnpj(new Bogus.DataSets.Company()), EDocumentType.CNPJ);

        }
    }
}
