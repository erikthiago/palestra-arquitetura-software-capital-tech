namespace SchoolOccurrences.Shared.Commons.Commands.Interfaces
{
    // Interface resposnsável por obrigar os commands a implementarem as validações
    public interface ICommand
    {
        void Validate();
    }
}
