using Flunt.Notifications;
using Flunt.Validations;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using System;

namespace SchoolOccurrences.School.Domain.Commands.Student
{
    //Representação do que é preciso para se excluir uma escola
    public class DeleteStudentCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
              .Requires()
              .AreNotEquals(Id, Guid.Empty, "Id", SharedMessages.InvalidId)
              );
        }
    }
}
