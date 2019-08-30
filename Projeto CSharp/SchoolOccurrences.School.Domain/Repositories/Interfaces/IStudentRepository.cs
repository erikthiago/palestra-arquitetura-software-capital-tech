using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System.Linq;

namespace SchoolOccurrences.School.Domain.Repositories.Interfaces
{
    // Classe responsável por implementar o que é específico no repositorio do aluno
    public interface IStudentRepository : IBaseRepositoryEntity<Student>, IBaseRepositoryDapper
    {
        IQuery GetStudent(string name);
        IQueryable<IQuery> GetStudentParents();
    }
}
