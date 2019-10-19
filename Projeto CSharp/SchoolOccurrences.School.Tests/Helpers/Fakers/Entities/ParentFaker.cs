using Bogus;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.Shared.Commons.Enums;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.ValueObjects
{
    public static class ParentFaker
    {
        public static Faker<Parent> Gerar()
        {
            Faker<Parent> parents = new Faker<Parent>("pt_BR")
                .RuleFor(p => p.ResponsibleName, f => f.Name.FullName())
                .RuleFor(p => p.ResponsibleDocument, f => PhysiqueDocument())
                .RuleFor(p => p.EFamilyType, f => f.PickRandom<EFamilyType>())
                .RuleFor(p => p.Telephone, f => f.Phone.PhoneNumberFormat())
                .RuleFor(p => p.AlternativeTelephone, f => f.Phone.PhoneNumberFormat())
                .RuleFor(p => p.ContactTelephone, f => f.Phone.PhoneNumberFormat());

            return parents;
        }

        private static Document PhysiqueDocument()
        {
            return new Document(Bogus.Extensions.Brazil.ExtensionsForBrazil.Cpf(new Person()), EDocumentType.CPF);
        }
    }
}
