using System.Linq;
using Dapper;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Infra.Contexts.Dapper;
using SchoolOccurrences.School.Infra.Contexts.Entity;
using SchoolOccurrences.School.Infra.Queries.Occurrence;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;

namespace SchoolOccurrences.School.Infra.Repositories
{
    public class OccurrenceRepository : BaseRepository<Occurrence>, IOccurrenceRepository
    {
        public OccurrenceRepository(EntityContext contextEntity, DapperContext contextDapper) : base(contextEntity, contextDapper)
        {
            _contextEntity = contextEntity;
            _contextDapper = contextDapper;
        }

        public IQueryable<IQuery> GetOccurrencesStudent()
        {
            return _contextDapper
               .Connection
               .Query<OccurrenceStudentQuery>(@"SELECT [OcrId] AS Id, [OcrTipo] AS OccurrenceType, [OcrCausa] AS Cause, [OcrDescricao] AS Description, 
                                             [OcrSituacao] AS OccurrenceStatus, [OcrData] AS Date, [EstNome] AS FirstName, [EstSobreNome] AS LastName,
                                             [EstSerie] AS Serie, [EstTurma] AS Grade
                                      FROM [OcrOcorrencia] INNER JOIN [EstEstudante] ON EstId = StudentId",
                                           new { }).AsQueryable();
        }
    }
}
