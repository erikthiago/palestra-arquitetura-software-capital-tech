using Flunt.Notifications;
using Flunt.Validations;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using System;

namespace SchoolOccurrences.School.Domain.Commands.Occurrence
{
    public class OccurrenceCommand : Notifiable
    {
        public EOccurrenceType OccurrenceType { get; set; }
        public string Cause { get; set; }
        public string Description { get; set; }
        public EOccurrenceStatus OccurrenceStatus { get; set; }
        public DateTime Date { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
             .Requires()
             //Validações da data
             .IsLowerThan(Date, DateTime.Now, "Date", OccurrenceMessages.InvalidDate)
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
