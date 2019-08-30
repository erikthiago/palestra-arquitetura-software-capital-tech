using PaymentContext.Shared.Handlers;
using SchoolOccurrences.School.Domain.Commands.School;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Domain.ValueObjects;
using SchoolOccurrences.Shared.Commons.Commands.Interfaces;
using SchoolOccurrences.Shared.Commons.Interfaces.UnitOfWork;
using Flunt.Notifications;
using SchoolOccurrences.Shared.Commons.Commands;
using SchoolOccurrences.Shared.Commons.Resources.Messages;

namespace SchoolOccurrences.School.Domain.Handlers
{
    // Classe responsável por realizar as chamadas ao repositorio para salvar, editar e excluir informações no banco de dados.
    public class SchoolCommandHandler : Notifiable,
        IHandler<CreateSchoolCommand>,
        IHandler<UpdateSchoolCommand>,
        IHandler<DeleteSchoolCommand>

    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWork _uow;

        public SchoolCommandHandler(ISchoolRepository schoolRepository, IUnitOfWork uow)
        {
            _schoolRepository = schoolRepository;
            _uow = uow;
        }

        // Cadastrasr uma nova escola
        public ICommandResult Handle(CreateSchoolCommand command)
        {
            // Valida os dados do command
            command.Validate();
            // Se for invalido, mostrar as notificações
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, SharedMessages.InvalidOperation, command);
            }

            // Preenche o VO document com as informações do command
            var document = new Document(command.DocumentNumber, command.Type);

            // Preenche o VO address com as informações do command
            var address = new Address(command.Street, 
                                      command.Number, 
                                      command.Neighborhood, 
                                      command.City, 
                                      command.StateName, 
                                      command.Country, 
                                      command.ZipCode,
                                      command.StateAbbr);

            // Preenche a entitie com os dados dos VOs e command
            var school = new Entities.School(command.Name, document, address, command.Phone);

            // Caso algum deles retorne erro, mostre as notificações
            AddNotifications(document, address, school);

            // Checando as notificações
            if (Invalid)
                return new CommandResult(false, SharedMessages.InvalidOperation, school);

            // Salvando informações
            if(!_schoolRepository.DocumentExists(command.DocumentNumber))
                _schoolRepository.Add(school);
            else
                return new CommandResult(false, SharedMessages.DocumentExists, school);

            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, school);
        }

        // Editar uma escola
        public ICommandResult Handle(UpdateSchoolCommand command)
        {
            // Valida os dados do command
            command.Validate();
            // Se for invalido, mostrar as notificações
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, SharedMessages.InvalidOperation, command);
            }

            // Preenche o VO document com as informações do command
            var document = new Document(command.DocumentNumber, command.Type);

            // Preenche o VO address com as informações do command
            var address = new Address(command.Street,
                                      command.Number,
                                      command.Neighborhood,
                                      command.City,
                                      command.StateName,
                                      command.Country,
                                      command.ZipCode,
                                      command.StateAbbr);

            // Preenche a entitie com os dados dos VOs e command
            var school = new Entities.School(command.Name, document, address, command.Phone);
            school.ChangeId(command.Id);

            // Caso algum deles retorne erro, mostre as notificações
            AddNotifications(document, address, school);

            // Checando as notificações
            if (Invalid)
                return new CommandResult(false, SharedMessages.InvalidOperation, school);

            // Salvando informações
            _schoolRepository.Update(school);
            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, school);
        }

        // Excluir uma escola
        public ICommandResult Handle(DeleteSchoolCommand command)
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
            _schoolRepository.Remove(command.Id);

            // Realizando a exclusão do banco de dados
            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, command.Id);
        }
    }
}
