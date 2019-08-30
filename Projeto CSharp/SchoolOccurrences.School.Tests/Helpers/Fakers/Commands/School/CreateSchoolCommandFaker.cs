using Bogus;
using Bogus.DataSets;
using SchoolOccurrences.School.Domain.Commands.School;
using SchoolOccurrences.Shared.Commons.Enums;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.School
{
    public static class CreateSchoolCommandFaker
    {
        public static Faker<CreateSchoolCommand> Gerar()
        {
            Faker<CreateSchoolCommand> createSchool = new Faker<CreateSchoolCommand>("pt_BR")
                .RuleFor(cs => cs.Name, f => f.Company.CompanyName())
                .RuleFor(cs => cs.DocumentNumber, JuridiqueDocument())
                .RuleFor(cs => cs.Type, f => EDocumentType.CNPJ)
                .RuleFor(cs => cs.Street, f => f.Address.StreetName())
                .RuleFor(cs => cs.Number, f => f.Random.Int(0, 1))
                .RuleFor(cs => cs.Neighborhood, f => f.Address.StreetAddress())
                .RuleFor(cs => cs.City, f => f.Address.State())
                .RuleFor(cs => cs.StateName, f => f.Address.State())
                .RuleFor(cs => cs.StateAbbr, f => f.PickRandom<EStates>())
                .RuleFor(cs => cs.Country, f => f.Address.County())
                .RuleFor(cs => cs.ZipCode, f => f.Address.ZipCode("#####-###"))
                .RuleFor(cs => cs.Phone, f => f.Phone.PhoneNumber());

            return createSchool;
        }

        private static string JuridiqueDocument()
        {
            return Bogus.Extensions.Brazil.ExtensionsForBrazil.Cnpj(new Company("pt_BR"));
        }
    }
}
