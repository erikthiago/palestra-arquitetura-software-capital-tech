namespace SchoolOccurrences.Shared.Commons.Commands
{
    // Classe responsável por mostrar a mensagem se o commit ocorreu com êxito ou não. Usada no UnitOfWork
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse { Success = true };
        public static CommandResponse Fail = new CommandResponse { Success = false };

        public CommandResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}
