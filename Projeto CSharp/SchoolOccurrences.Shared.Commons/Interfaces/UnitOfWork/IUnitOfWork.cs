using SchoolOccurrences.Shared.Commons.Commands;
using System;

namespace SchoolOccurrences.Shared.Commons.Interfaces.UnitOfWork
{
    // Interface que cria o contrato na classe UnitOfWork. Obriga a implementar o método commit
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
