using Flunt.Notifications;
using Flunt.Validations;
using SchoolOccurrences.School.Domain.Commands.Student;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using System;

namespace SchoolOccurrences.School.Domain.Commands.Occurrence
{
    public class CreateOccurrenceCommand : Notifiable, ICommand
    {
        public EOccurrenceType OccurrenceType { get; set; }
        public string Cause { get; set; }
        public string Description { get; set; }
        public EOccurrenceStatus OccurrenceStatus { get; set; }
        public DateTime Date { get; set; }
        // Referencia do aluno relacionado a ocorrência
        public Guid StudentId { get;set; }

        public void Validate()
        {
            AddNotifications(new Contract()
             .Requires()
             //Validações da data
             .IsLowerThan(Date.Date, DateTime.Now.AddDays(1), "Data", OccurrenceMessages.InvalidDate)
             //Validações da causa
             .HasMinLen(Cause, 1, "Cause", string.Format(SharedMessages.MinLength, "Causa", 1))
             .HasMaxLen(Cause, 255, "Cause", string.Format(SharedMessages.MaxLength, "Causa", 255))
             //Validações da descrição
             .HasMinLen(Description, 1, "Description", string.Format(SharedMessages.MinLength, "Descrição", 1))
             .HasMaxLen(Description, 255, "Description", string.Format(SharedMessages.MaxLength, "Descrição", 255))
             );
        }
    }
}
