using Flunt.Notifications;
using PaymentContext.Shared.Handlers;
using SchoolOccurrences.School.Domain.Commands.Student;
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
    public class StudentCommandHandler : Notifiable,
        IHandler<CreateStudentCommand>,
        IHandler<UpdateStudentCommand>,
        IHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _uow;

        public StudentCommandHandler(IStudentRepository schoolRepository, IUnitOfWork uow)
        {
            _studentRepository = schoolRepository;
            _uow = uow;
        }

        // Cadastrar um novo aluno
        public ICommandResult Handle(CreateStudentCommand command)
        {
            // Variaveis necessarias
            Student student = new Student();
            Parent parent = new Parent();
            Document parentDocument = new Document();
            Email parentEmail = new Email();

            // Valida os dados do command
            command.Validate();

            // Se for invalido, mostrar as notificações
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, SharedMessages.InvalidOperation, command);
            }

            // Preenchendo os VOs do aluno
            var studentName = new Name(command.FirstName, command.LastName);
            var studentAddress = new Address(command.Street,
                                   command.Number,
                                   command.Neighborhood,
                                   command.City,
                                   command.StateName,
                                   command.Coutry,
                                   command.ZipCode,
                                   command.Abbr);

            // Preenchendo o objeto aluno
            student = new Student(studentName,
                                  studentAddress,
                                  command.BirthDate,
                                  command.ETypeOfEducation,
                                  command.AcademicYear,
                                  command.Serie,
                                  command.Grade,
                                  command.Shifts,
                                  command.CalledNumber,
                                  command.Note);
            student.SetSchoolId(command.SchoolId);

            //Preenchendo o objeto dos responsáveis
            for (int i = 0; i < command.Parents.Count; i++)
            {
                // Preenchendo os VOs do responsável
                parentDocument = new Document(command.Parents[i].DocumentNumber, command.Parents[i].Type);
                parentEmail = new Email(command.Parents[i].AddressEmail);

                // Preenchendo o objeto responsável
                parent = new Parent(command.Parents[i].ResponsibleName,
                                     parentDocument, 
                                     command.Parents[i].EFamilyType, 
                                     parentEmail, 
                                     command.Parents[i].Telephone);
                parent.AddUpdateAlternativeTelephone(command.Parents[i].AlternativeTelephone);
                parent.AddUpdateContactTelephone(command.Parents[i].ContactTelephone);
                // Adicionando o responsável ao aluno
                student.AddParents(parent);
            }

            // Caso algum deles retorne erro, mostre as notificações
            AddNotifications(parentDocument, parentEmail, parent, 
                             studentName, studentAddress, student);

            // Checando as notificações
            if (Invalid)
                return new CommandResult(false, SharedMessages.InvalidOperation, student);

            // Adicionando ao contexto o objeto aluno
            _studentRepository.Add(student);

            // Realizando a confirmação do salvamento do objeto
            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, student);
        }

        // Editar um aluno
        public ICommandResult Handle(UpdateStudentCommand command)
        {
            // Variaveis necessarias
            Student student = new Student();
            Parent parent = new Parent();
            Document parentDocument = new Document();
            Email parentEmail = new Email();

            // Valida os dados do command
            command.Validate();

            // Se for invalido, mostrar as notificações
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, SharedMessages.InvalidOperation, command);
            }

            // Preenchendo os VOs do aluno
            var studentName = new Name(command.FirstName, command.LastName);
            var studentAddress = new Address(command.Street,
                                   command.Number,
                                   command.Neighborhood,
                                   command.City,
                                   command.StateName,
                                   command.Coutry,
                                   command.ZipCode,
                                   command.Abbr);

            // Preenchendo o objeto aluno
            student = new Student(studentName,
                                  studentAddress,
                                  command.BirthDate,
                                  command.ETypeOfEducation,
                                  command.AcademicYear,
                                  command.Serie,
                                  command.Grade,
                                  command.Shifts,
                                  command.CalledNumber,
                                  command.Note);
            student.ChangeId(command.Id);
            student.SetSchoolId(command.SchoolId);

            //Preenchendo o objeto dos responsáveis
            for (int i = 0; i < command.Parents.Count; i++)
            {
                // Preenchendo os VOs do responsável
                parentDocument = new Document(command.Parents[i].DocumentNumber, command.Parents[i].Type);
                parentEmail = new Email(command.Parents[i].AddressEmail);

                // Preenchendo o objeto responsável
                parent = new Parent(command.Parents[i].ResponsibleName,
                                     parentDocument,
                                     command.Parents[i].EFamilyType,
                                     parentEmail,
                                     command.Parents[i].Telephone);
                parent.ChangeId(command.Parents[i].Id);
                parent.AddUpdateAlternativeTelephone(command.Parents[i].AlternativeTelephone);
                parent.AddUpdateContactTelephone(command.Parents[i].ContactTelephone);

                // Adicionando o responsável ao aluno
                student.AddParents(parent);
            }

            // Caso algum deles retorne erro, mostre as notificações
            AddNotifications(parentDocument, parentEmail, parent,
                             studentName, studentAddress, student);

            // Checando as notificações
            if (Invalid)
                return new CommandResult(false, SharedMessages.InvalidOperation, student);

            // Adicionando ao contexto o objeto aluno
            _studentRepository.Update(student);

            // Realizando a confirmação do salvamento do objeto
            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, student);
        }

        // Excluir um aluno
        public ICommandResult Handle(DeleteStudentCommand command)
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
            _studentRepository.Remove(command.Id);

            // Realizando a exclusão do banco de dados
            _uow.Commit();

            // Retornando informações de sucesso e o objeto preenchido
            return new CommandResult(true, SharedMessages.SuccedOperation, command.Id);
        }
    }
}
