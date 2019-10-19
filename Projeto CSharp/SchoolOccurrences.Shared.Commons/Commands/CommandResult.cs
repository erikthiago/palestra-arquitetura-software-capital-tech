using SchoolOccurrences.Shared.Commons.Commands.Interfaces;

namespace SchoolOccurrences.Shared.Commons.Commands
{
    //Resposável por transitar as mensagens retornadas pelos commands
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set ; }
        public object Data { get; set; }
    }
}
