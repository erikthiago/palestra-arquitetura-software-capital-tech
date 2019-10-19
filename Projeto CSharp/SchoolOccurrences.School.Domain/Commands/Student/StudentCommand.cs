using Flunt.Notifications;
using Flunt.Validations;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Enums;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using SchoolOccurrences.Shared.Commons.Validations;
using System;

namespace SchoolOccurrences.School.Domain.Commands.Student
{
    public class StudentCommand : Notifiable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public EStates Abbr { get; set; }
        public string Coutry { get; set; }
        public string ZipCode { get; set; }
        public DateTime BirthDate { get; set; }
        //Verificar depois uma forma de implementar
        //public string Photo { get; set; }
        public ETypeOfEducation ETypeOfEducation { get; set; }
        public DateTime AcademicYear { get; set; }
        public int Serie { get; set; }
        public string Grade { get; set; }
        public EShifts Shifts { get; set; }
        public int CalledNumber { get; set; }
        public string Note { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            //Validações da serie
            .IsTrue(Serie > 0, "Serie", StudentMessages.InvalidSerie)
            //Validações da turma
            .IsNotNullOrEmpty(Grade, "Grade", StudentMessages.IinvalidGrade)
            .HasMaxLen(Grade, 1, "Grade", string.Format(SharedMessages.MaxLength, "Turma", 1))
            //Validações do nome
            .IsNotNullOrEmpty(FirstName, "FirstName", SharedMessages.InvalidFirstName)
            .HasMinLen(FirstName, 3, "FirstName", string.Format(SharedMessages.MinLength, "Nome", 3))
            .HasMaxLen(FirstName, 40, "FirstName", string.Format(SharedMessages.MaxLength, "Nome", 40))
            //Validações do sobrenome
            .IsNotNullOrEmpty(LastName, "LastName", SharedMessages.InvalidLastName)
            .HasMinLen(LastName, 3, "LastName", string.Format(SharedMessages.MinLength, "SobreNome", 3))
            .HasMaxLen(LastName, 40, "LastName", string.Format(SharedMessages.MinLength, "SobreNome", 40))
            //Validações sobre a rua
            .IsNotNullOrEmpty(Street, "Street", SharedMessages.InvalidStreet)
            .HasMinLen(Street, 3, "Street", string.Format(SharedMessages.MinLength, "Rua", 3))
            .HasMaxLen(Street, 50, "Street", string.Format(SharedMessages.MaxLength, "Rua", 50))
            //Validações sobre o bairro
            .IsNotNullOrEmpty(Neighborhood, "Neighborhood", SharedMessages.InvalidNeighborhood)
            .HasMinLen(Neighborhood, 3, "Neighborhood", string.Format(SharedMessages.MinLength, "Bairro", 3))
            .HasMaxLen(Neighborhood, 50, "Neighborhood", string.Format(SharedMessages.MaxLength, "Bairro", 50))
            //validações sobre a cidade
            .IsNotNullOrEmpty(City, "City", SharedMessages.InvalidNeighborhood)
            .HasMinLen(City, 3, "City", string.Format(SharedMessages.MinLength, "Cidade", 3))
            .HasMaxLen(City, 50, "City", string.Format(SharedMessages.MaxLength, "Cidade", 50))
            //validações do CEP
            .IsNotNullOrEmpty(ZipCode, "ZipCode", SharedMessages.InvalidNeighborhood)
            .IsTrue(CepValidation.ValidaCEP(ZipCode), "ZipCode", SharedMessages.InvalidZipCode)
            );
        }
    }
}
