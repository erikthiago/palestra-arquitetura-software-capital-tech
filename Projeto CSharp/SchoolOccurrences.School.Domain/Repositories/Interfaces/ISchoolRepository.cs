using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System.Linq;

namespace SchoolOccurrences.School.Domain.Repositories.Interfaces
{
    // Classe responsável por implementar o que é específico no repositorio da escola
    public interface ISchoolRepository : IBaseRepositoryEntity<Entities.School>, IBaseRepositoryDapper
    {
        IQuery GetSchool(string document);
        bool DocumentExists(string document);
        IQueryable<IQuery> GetSchoolStudents();
    }
}
