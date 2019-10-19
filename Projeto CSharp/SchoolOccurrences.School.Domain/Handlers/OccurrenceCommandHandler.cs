using Flunt.Notifications;
using PaymentContext.Shared.Handlers;
using SchoolOccurrences.School.Domain.Commands.Occurrence;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.Shared.Commons.Commands;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Interfaces.UnitOfWork;
using SchoolOccurrences.Shared.Commons.Resources.Messages;

namespace SchoolOccurrences.School.Domain.Handlers
{
    // Classe responsável por realizar as chamadas ao repositorio para salvar, editar e excluir informações no banco de dados.
    public class OccurrenceCommandHandler : Notifiable,
        IHandler<CreateOccurrenceCommand>,
        IHandler<UpdateOccurrenceCommand>,
        IHandler<DeleteOccurrenceCommand>
    {
        private readonly IOccurrenceRepository _repositoryOccurrence;
        private readonly IUnitOfWork _uow;

        public OccurrenceCommandHandler(IOccurrenceRepository repositoryOccurrence, IUnitOfWork uow)
        {
            _repositoryOccurrence = repositoryOccurrence;
            _uow = uow;
        }

        // Cadastrar uma nova ocorrência
        public ICommandResult Handle(CreateOccurrenceCommand command)
        {
            // Valida os dados do command
            command.Validate();

            // Se for invalido, mostrar as notificações
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, SharedMessages.InvalidOperation, command);
            }

            // Preenchendo o objeto ocorrência
            var occurrence = new Occurrence(command.OccurrenceType, command.Cause, command.Description, command.OccurrenceStatus, command.Date);
            occurrence.addStudentId(command.StudentId);

            // Mostre as notificações
            AddNotifications(occurrence);

            // Checando as notificações
            if (Invalid)
                return new CommandResult(false, SharedMessages.InvalidOperation, occurrence);


            // Adicionando ao contexto o objeto aluno
            _repositoryOccurrence.Add(occurrence);

            // Realizando a confirmação do salvamento do objeto
            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, occurrence);
        }

        // Editar uma ocorrência
        public ICommandResult Handle(UpdateOccurrenceCommand command)
        {
            // Valida os dados do command
            command.Validate();

            // Se for invalido, mostrar as notificações
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, SharedMessages.InvalidOperation, command);
            }

            // Preenchendo o objeto ocorrência
            var occurrence = new Occurrence(command.OccurrenceType, command.Cause, command.Description, command.OccurrenceStatus, command.Date);
            occurrence.ChangeId(command.Id);
            occurrence.addStudentId(command.StudentId);

            // Mostre as notificações
            AddNotifications(occurrence);

            // Checando as notificações
            if (Invalid)
                return new CommandResult(false, SharedMessages.InvalidOperation, occurrence);


            // Adicionando ao contexto o objeto aluno
            _repositoryOccurrence.Update(occurrence);

            // Realizando a confirmação do salvamento do objeto
            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, occurrence);
        }

        // Excluir uma ocorrência
        public ICommandResult Handle(DeleteOccurrenceCommand command)
        {
            // Valida os dados do command
            command.Validate();
            // Se for invalido, mostrar as notificações
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, SharedMessages.InvalidOperation, command);
            }

            // Deletando as  informações
            _repositoryOccurrence.Remove(command.Id);

            // Realizando a exclusão do banco de dados
            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, command.Id);
        }
    }
}
