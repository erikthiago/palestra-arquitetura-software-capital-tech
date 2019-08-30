using Flunt.Notifications;
using Flunt.Validations;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Resources.Messages;
using System;

namespace SchoolOccurrences.School.Domain.Commands.Occurrence
{
    public class DeleteOccurrenceCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
              .Requires()
              .AreNotEquals(Guid.Empty, Id, "Id", SharedMessages.InvalidId)
              );
        }
    }
}
