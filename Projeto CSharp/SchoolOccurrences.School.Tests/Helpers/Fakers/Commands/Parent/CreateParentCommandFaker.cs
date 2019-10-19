using Bogus;
using SchoolOccurrences.School.Domain.Commands.Parent;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Enums;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Parent
{
    public static class CreateParentCommandFaker
    {
        public static Faker<CreateParentCommand> Gerar()
        {
            Faker<CreateParentCommand> createParent = new Faker<CreateParentCommand>("pt_BR")
                .RuleFor(cp => cp.ResponsibleName, f => f.Name.FullName())
                .RuleFor(cp => cp.DocumentNumber, f => PhysiqueDocument())
                .RuleFor(cp => cp.Type, f => f.PickRandom<EDocumentType>())
                .RuleFor(cp => cp.EFamilyType, f => f.PickRandom<EFamilyType>())
                .RuleFor(cp => cp.Telephone, f => f.Phone.PhoneNumberFormat())
                .RuleFor(cp => cp.AlternativeTelephone, f => f.Phone.PhoneNumberFormat())
                .RuleFor(cp => cp.ContactTelephone, f => f.Phone.PhoneNumberFormat());

            return createParent;
        }

        private static string PhysiqueDocument()
        {
            return Bogus.Extensions.Brazil.ExtensionsForBrazil.Cpf(new Person("pt_BR"));
        }
    }
}
