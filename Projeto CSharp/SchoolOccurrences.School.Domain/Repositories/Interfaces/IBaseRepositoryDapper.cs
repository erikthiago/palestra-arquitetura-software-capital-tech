using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System;
using System.Linq;

namespace SchoolOccurrences.School.Domain.Repositories.Interfaces
{
    // Inteface responsável por implementar o minimo necessário no repositorio
    public interface IBaseRepositoryDapper : IDisposable
    {
        IQueryable<IQuery> GetAllSchools();
        IQueryable<IQuery> GetAllStudents();
        IQueryable<IQuery> GetAllOccurrences();
    }
}
