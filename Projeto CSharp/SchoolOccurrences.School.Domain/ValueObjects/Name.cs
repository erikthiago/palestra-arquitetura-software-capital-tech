using Flunt.Validations;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using SchoolOccurrences.Shared.Commons.ValueObjects;

namespace SchoolOccurrences.School.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name()
        {

        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
               .Requires()
               //Validações do nome
               .IsNotNullOrEmpty(FirstName, "FirstName", SharedMessages.InvalidFirstName)
               .HasMinLen(FirstName, 3, "FirstName", string.Format(SharedMessages.MinLength, "Nome", 3))
               .HasMaxLen(FirstName, 40, "FirstName", string.Format(SharedMessages.MaxLength, "Nome", 40))
               //Validações do sobrenome
               .IsNotNullOrEmpty(LastName, "LastName", SharedMessages.InvalidLastName)
               .HasMinLen(LastName, 3, "LastName", string.Format(SharedMessages.MinLength, "SobreNome", 3))
               .HasMaxLen(LastName, 40, "LastName", string.Format(SharedMessages.MinLength, "SobreNome", 40))
               );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        /// <summary>
        /// MÉTODO PARA CONCATENAR NOME E SOBRENOME DO ALUNO
        /// </summary>
        /// <returns>NOME E SOBRENOME</returns>
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
