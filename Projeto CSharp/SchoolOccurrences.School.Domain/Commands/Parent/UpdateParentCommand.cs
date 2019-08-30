using Flunt.Notifications;
using Flunt.Validations;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using SchoolOccurrences.Shared.Commons.Validations;
using System;

namespace SchoolOccurrences.School.Domain.Commands.Parent
{
    public class UpdateParentCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string ResponsibleName { get; set; }
        public string DocumentNumber { get; set; }
        public EDocumentType Type { get; set; }
        public EFamilyType EFamilyType { get; set; }
        public string Telephone { get; set; }
        public string AlternativeTelephone { get; set; }
        public string ContactTelephone { get; set; }
        public string AddressEmail { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
             .Requires()
             //Validações do nome do responsável
             .IsNotNullOrEmpty(ResponsibleName, "ResponsibleName", StudentMessages.InvalidMothersName)
             .HasMinLen(ResponsibleName, 3, "ResponsibleName", string.Format(SharedMessages.MinLength, "Nome da responsável", 3))
             .HasMaxLen(ResponsibleName, 100, "ResponsibleName", string.Format(SharedMessages.MinLength, "Nome do responsável", 100))
             //Validações do e-mail
             .IsEmail(AddressEmail, "AddressEmail", SharedMessages.InvalidEmail)
             //Validação do número do documento(CPF ou CNPJ)
             .IsTrue(DocumentValidate(), "DocumentNumber", SharedMessages.InvalidDocumentNumber)
             );
        }

        private bool DocumentValidate()
        {
            if (Type == EDocumentType.CNPJ && DocumentValidation.ValidaCNPJ(DocumentNumber))
                return true;

            if (Type == EDocumentType.CPF && DocumentValidation.ValidaCPF(DocumentNumber))
                return true;

            return false;
        }
    }
}
