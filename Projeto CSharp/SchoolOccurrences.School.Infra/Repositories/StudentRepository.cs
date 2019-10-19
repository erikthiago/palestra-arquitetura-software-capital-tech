using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Infra.Contexts.Dapper;
using SchoolOccurrences.School.Infra.Contexts.Entity;
using SchoolOccurrences.School.Infra.Queries.Student;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System.Linq;
using Dapper;

namespace SchoolOccurrences.School.Infra.Repositories
{
    // Classe responsável por implementar o que é especifico do aluno.
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(EntityContext contextEntity, DapperContext contextDapper) : base(contextEntity, contextDapper)
        {
            _contextEntity = contextEntity;
            _contextDapper = contextDapper;
        }

        public IQuery GetStudent(string estName)
        {
            return _contextDapper
               .Connection
               .Query<StudentQuery>(@"SELECT [EstId] AS Id, [EstNome] AS FirstName, [EstSobreNome] AS LastName, [EstRua] AS Street, 
                                             [EstEnderecoNumero] AS Number, [EstBairro] AS Neighborhood, [EstCidade] AS City, 
                                             [EstUf] AS StateName, [EstSiglaUf] AS Abbr, [EstPais] AS Country, [EstCep] AS ZipCode, 
                                             [EstTipoEnsino] AS ETypeOfEducation, [EstAnoLetivo] AS AcademicYear, [EstDataNascimento] AS BirthDate,
                                             [EstSerie] AS Serie, [EstTurma] AS Grade, [EstTurno] AS Shifts, [EstNumeroChamada] AS CalledNumber, 
                                             [EstObservacao] AS Note
                                      FROM [EstEstudante] 
                                      WHERE [EstNome] LIKE @EstNome" ,
                                          new { EstNome =  "%" + estName + "%"}).FirstOrDefault();
        }

        public IQueryable<IQuery> GetStudentParents()
        {
            return _contextDapper
               .Connection
               .Query<StudentParentsQuery>(@"SELECT [EstId] AS Id, [EstNome] AS StudentFirstName, [EstSobreNome] AS StudentLastName, [EstSerie] AS Serie, 
                                             [EstTurma] AS Grade, [ResNome] AS ResponsibleName, [ResNumeroDocumento] AS ResponsibleDocumentNumber, 
                                             [ResTipoDocumento] AS Type, [ResFamiliaridade] AS EFamilyType, [ResTelefonePrincipal] AS ResponsibleTelephone, 
                                             [ResEmail] AS ResponsibleEmail, [ResId] AS ResponsibleId
                                      FROM [EstEstudante] INNER JOIN [ResResponsavel] ON EstId = StudentId",
                                           new { }).AsQueryable();
        }
    }
}
