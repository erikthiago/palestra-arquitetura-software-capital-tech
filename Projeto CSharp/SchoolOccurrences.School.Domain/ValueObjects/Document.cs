using Flunt.Validations;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using SchoolOccurrences.Shared.Commons.Validations;
using SchoolOccurrences.Shared.Commons.ValueObjects;

namespace SchoolOccurrences.School.Domain.ValueObjects
{
    //usado para OO e evitar muitas linhas de código
    public class Document : ValueObject
    {
        public Document()
        {

        }

        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
               .Requires()
               //Validação do número do documento(CPF ou CNPJ)
               .IsTrue(Validate(), "Numer", SharedMessages.InvalidDocumentNumber)
               );
        } 

        public string Number { get; private set; }

        public EDocumentType Type { get; private set; }

        private bool Validate()
        {
            if (Type == EDocumentType.CNPJ && DocumentValidation.ValidaCNPJ(Number))
                return true;

            if (Type == EDocumentType.CPF && DocumentValidation.ValidaCPF(Number))
                return true;

            return false;
        }
    }
}
