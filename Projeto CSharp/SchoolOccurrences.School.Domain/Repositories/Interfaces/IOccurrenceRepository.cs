using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System.Linq;

namespace SchoolOccurrences.School.Domain.Repositories.Interfaces
{
    // Classe responsável por implementar o que é específico no repositorio da ocorrência
    public interface IOccurrenceRepository : IBaseRepositoryEntity<Occurrence>, IBaseRepositoryDapper
    {
        IQueryable<IQuery> GetOccurrencesStudent();
    }
}
