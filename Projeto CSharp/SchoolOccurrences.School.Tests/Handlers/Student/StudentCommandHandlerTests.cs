using AutoMoqCore;
using Bogus;
using Moq;
using SchoolOccurrences.School.Domain.Commands.Student;
using SchoolOccurrences.School.Domain.Handlers;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.Student;
using Xunit;

namespace SchoolOccurrences.School.Tests.Handlers.Student
{
    public class StudentCommandHandlerTests
    {
        private Faker<CreateStudentCommand> createStudent;

        [Fact]
        public void DeveRetornarCadastroHanlderValido()
        {
            // Arrange
            // Criando o faker do objeto do command para salvar uma nova escola
            createStudent = CreateStudentCommandFaker.Gerar();
            var command = createStudent.Generate();

            // Criando o mock do handler
            var mocker = new AutoMoqer();
            mocker.Create<StudentCommandHandler>();

            // Resolvendo as dependencias do construtor
            var studentCommandHandler = mocker.Resolve<StudentCommandHandler>();
            // Mockando o respositorio
            var repository = mocker.GetMock<IStudentRepository>();

            // Act
            // Chamando a rotina para cadastrar uma nova escola mockada
            studentCommandHandler.Handle(command);

            // Asset
            // Verificando se deu certo a inserção chamando o repositorio
            repository.Verify(r => r.Add(It.IsAny<Domain.Entities.Student>()),
                                   Times.Exactly(1));
        }
    }
}
