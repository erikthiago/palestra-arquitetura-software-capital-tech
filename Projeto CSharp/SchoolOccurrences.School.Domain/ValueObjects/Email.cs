using Flunt.Validations;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using SchoolOccurrences.Shared.Commons.ValueObjects;

namespace SchoolOccurrences.School.Domain.ValueObjects
{
    //usado para OO e evitar muitas linhas de código
    public class Email : ValueObject
    {
        public Email()
        {

        }

        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                //Validação do e-mail
                .IsEmail(Address, "Address", SharedMessages.InvalidEmail)
                );
        }

        public string Address { get; private set; }
    }
}
