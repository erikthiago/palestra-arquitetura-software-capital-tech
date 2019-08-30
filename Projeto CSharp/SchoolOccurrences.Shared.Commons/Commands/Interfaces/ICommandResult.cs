namespace SchoolOccurrences.Shared.Commons.Commands.Interfaces
{
    // Retorno dos commands e retorno das mensagens dos commands
    public interface ICommandResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
