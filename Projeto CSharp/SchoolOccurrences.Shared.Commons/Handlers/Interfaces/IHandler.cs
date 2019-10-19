using SchoolOccurrences.Shared.Commons.Commands.Interfaces;

namespace PaymentContext.Shared.Handlers
{
    // Organizar as chamadas dos handlers para operações de banco de dados passando os commands
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
