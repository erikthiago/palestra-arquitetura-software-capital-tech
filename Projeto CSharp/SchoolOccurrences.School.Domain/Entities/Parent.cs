using Flunt.Validations;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.Shared.Commons.Entities;
using SchoolOccurrences.Shared.Commons.Resources.Messages;

namespace SchoolOccurrences.School.Domain.Entities
{
    public class Parent : Entity
    {
        //Utilziado pelo Entity
        public Parent()
        {

        }

        public Parent(string responsibleName, 
                       Document responsibleDocument,
                       EFamilyType eFamilyType,
                       Email email,
                       string telephone)
        {
            ResponsibleName = responsibleName;
            ResponsibleDocument = responsibleDocument;
            EFamilyType = eFamilyType;
            Email = email;
            Telephone = telephone;

            AddNotifications(new Contract()
             .Requires()
             //Validações do nome do responsável
             .IsNotNullOrEmpty(ResponsibleName, "ResponsibleName", StudentMessages.InvalidMothersName)
             .HasMinLen(ResponsibleName, 3, "ResponsibleName", string.Format(SharedMessages.MinLength, "Nome da responsável", 3))
             .HasMaxLen(ResponsibleName, 100, "ResponsibleName", string.Format(SharedMessages.MinLength, "Nome do responsável", 100))
             );
        }

        public string ResponsibleName { get; private set; }
        public Document ResponsibleDocument { get; private set; }
        public EFamilyType EFamilyType { get; private set; }
        public string Telephone { get; private set; }
        public string AlternativeTelephone { get; private set; }
        public string ContactTelephone { get; private set; }
        public Email Email { get; private set; }
        public virtual Student Student { get; private set; }

        public void AddUpdateAlternativeTelephone(string alternativeTelephone)
        {
            AlternativeTelephone = alternativeTelephone;
        }

        public void AddUpdateContactTelephone(string contactTelephone)
        {
            ContactTelephone = contactTelephone;
        }
    }
}
