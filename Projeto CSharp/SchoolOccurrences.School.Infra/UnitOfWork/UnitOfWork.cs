using SchoolOccurrences.School.Infra.Contexts.Entity;
using SchoolOccurrences.Shared.Commons.Commands;
using SchoolOccurrences.Shared.Commons.Interfaces.UnitOfWork;
using System;

namespace SchoolOccurrences.School.Infra.UnitOfWork
{
    // Classe responsável por efetivar as transações do banco de dados e manter a atomicidade do dado.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _context;

        public UnitOfWork(EntityContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            try
            {
                var rowsAffected = _context.SaveChanges();
                return new CommandResponse(rowsAffected > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
