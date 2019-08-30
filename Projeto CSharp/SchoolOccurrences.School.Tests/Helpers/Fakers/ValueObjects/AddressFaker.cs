using Bogus;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.Shared.Commons.Enums;

namespace SchoolOccurrences.School.Tests.Helpers.Fakers.ValueObjects
{
    public static class AddressFaker
    {
        public static Faker<Address> Gerar()
        {
            Faker<Address> address = new Faker<Address>("pt_BR")
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.Number, f => f.Random.Int(0, 1))
                .RuleFor(a => a.Neighborhood, f => f.Address.SecondaryAddress())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.ZipCode, f => f.Address.ZipCode("#####-###"))
                .RuleFor(s => s.StateName, f => f.Address.State())
                .RuleFor(s => s.Abbr, f => f.PickRandom<EStates>());

            return address;
        }
    }
}
