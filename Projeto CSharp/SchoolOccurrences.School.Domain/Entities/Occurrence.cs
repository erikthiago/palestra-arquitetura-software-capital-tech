using Flunt.Validations;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.Shared.Commons.Entities;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using System;

namespace SchoolOccurrences.School.Domain.Entities
{
    public class Occurrence : Entity
    {
        //Utilizado pelo Entity
        public Occurrence()
        {

        }

        public Occurrence(EOccurrenceType occurrenceType, string cause, string description, EOccurrenceStatus occurrenceStatus, DateTime date)
        {
            OccurrenceType = occurrenceType;
            Cause = cause;
            Description = description;
            OccurrenceStatus = occurrenceStatus;
            Date = date;

            AddNotifications(new Contract()
             .Requires()
             //Validações da data
             .IsLowerThan(Date.Date, DateTime.Now.AddDays(1), "Date", OccurrenceMessages.InvalidDate)
             //Validações da causa
             .HasMinLen(Cause, 1, "Cause", string.Format(SharedMessages.MinLength, "Causa", 1))
             .HasMaxLen(Cause, 255, "Cause", string.Format(SharedMessages.MaxLength, "Causa", 255))
             //Validações da descrição
             .HasMinLen(Description, 1, "Description", string.Format(SharedMessages.MinLength, "Descrição", 1))
             .HasMaxLen(Description, 255, "Description", string.Format(SharedMessages.MaxLength, "Descrição", 255))
             );
        }

        public EOccurrenceType OccurrenceType { get; private set; }
        public string Cause { get; private set; }
        public string Description { get; private set; }
        public EOccurrenceStatus OccurrenceStatus { get; private set; }
        public DateTime Date { get; set; }

        // Um aluno para várias ocorrências
        public Guid StudentId { get; private set; }
        public Student Student { get; private set; }
        //relacionamento com usuário

        public void addStudentId(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
