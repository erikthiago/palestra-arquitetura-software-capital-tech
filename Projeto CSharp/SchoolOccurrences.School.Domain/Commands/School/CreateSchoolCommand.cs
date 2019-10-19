using Flunt.Notifications;
using Flunt.Validations;
using SchoolOccurrences.School.Domain.Commands.Student;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using SchoolOccurrences.Shared.Commons.Validations;
using System.Collections.Generic;

namespace SchoolOccurrences.School.Domain.Commands.School
{
    //Representação do que é preciso para se cadastrar uma escola
    public class CreateSchoolCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public EDocumentType Type { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public EStates StateAbbr { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        
        public void Validate()
        {
            AddNotifications(new Contract()
              .Requires()
              //Validações do nome
              .IsNotNullOrEmpty(Name, "Name", SharedMessages.InvalidFirstName)
              .HasMinLen(Name, 3, "Name", string.Format(SharedMessages.MinLength, "Nome", 3))
              .HasMaxLen(Name, 40, "Name", string.Format(SharedMessages.MaxLength, "Nome", 40))
              //Validações do número do documento
              .IsTrue(DocumentValidate(), "DocumentNumber", SharedMessages.InvalidDocumentNumber)
              //Validações da rua
              .IsNotNullOrEmpty(Street, "Street", SharedMessages.InvalidFirstName)
              .HasMinLen(Street, 3, "Street", string.Format(SharedMessages.MinLength, "Rua", 3))
              .HasMaxLen(Street, 40, "Street", string.Format(SharedMessages.MaxLength, "Rua", 40))
              //Validações do bairro
              .IsNotNullOrEmpty(Neighborhood, "Neighborhood", SharedMessages.InvalidFirstName)
              .HasMinLen(Neighborhood, 3, "Neighborhood", string.Format(SharedMessages.MinLength, "Bairro", 3))
              .HasMaxLen(Neighborhood, 40, "Neighborhood", string.Format(SharedMessages.MaxLength, "Bairro", 40))
              //Validações da cidade
              .IsNotNullOrEmpty(City, "City", SharedMessages.InvalidFirstName)
              .HasMinLen(City, 3, "City", string.Format(SharedMessages.MinLength, "Cidade", 3))
              .HasMaxLen(City, 40, "City", string.Format(SharedMessages.MaxLength, "Cidade", 40))
              //Validações do nome do estado
              .IsNotNullOrEmpty(StateName, "StateName", SharedMessages.InvalidFirstName)
              .HasMinLen(StateName, 3, "StateName", string.Format(SharedMessages.MinLength, "Estado", 3))
              .HasMaxLen(StateName, 40, "StateName", string.Format(SharedMessages.MaxLength, "Estado", 40))
              //Validações do cep
              .IsNotNullOrEmpty(ZipCode, "ZipCode", SharedMessages.InvalidNeighborhood)
              .IsTrue(CepValidation.ValidaCEP(ZipCode), "ZipCode", SharedMessages.InvalidZipCode)
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
