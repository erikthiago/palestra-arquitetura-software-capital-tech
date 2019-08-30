using AutoMoqCore;
using Bogus;
using Moq;
using SchoolOccurrences.School.Domain.Commands.School;
using SchoolOccurrences.School.Domain.Handlers;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Tests.Helpers.Fakers.Commands.School;
using Xunit;

namespace SchoolOccurrences.School.Tests.Handlers.School
{
    public class SchoolCommandHandlerTests
    {
        private Faker<CreateSchoolCommand> createSchool;

        [Fact]
        public void DeveRetornarCadastroHanlderValido()
        {
            // Arrange
            // Criando o faker do objeto do command para salvar uma nova escola
            createSchool = CreateSchoolCommandFaker.Gerar();
            var command = createSchool.Generate();

            // Criando o mock do handler
            var mocker = new AutoMoqer();
            mocker.Create<SchoolCommandHandler>();

            // Resolvendo as dependencias do construtor
            var schoolCommandHandler = mocker.Resolve<SchoolCommandHandler>();
            // Mockando o respositorio
            var repository = mocker.GetMock<ISchoolRepository>();

            // Act
            // Chamando a rotina para cadastrar uma nova escola mockada
            schoolCommandHandler.Handle(command);

            // Asset
            // Verificando se deu certo a inserção chamando o repositorio
            repository.Verify(r => r.Add(It.IsAny<Domain.Entities.School>()),
                                   Times.Exactly(1));
        }
    }
}
