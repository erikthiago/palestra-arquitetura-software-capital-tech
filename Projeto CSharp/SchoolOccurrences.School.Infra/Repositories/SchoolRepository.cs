using Dapper;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Infra.Contexts.Dapper;
using SchoolOccurrences.School.Infra.Contexts.Entity;
using SchoolOccurrences.School.Infra.Queries.School;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System.Linq;

namespace SchoolOccurrences.School.Infra.Repositories
{
    // Classe responsável por implementar o que é especifico da escola.
    public class SchoolRepository : BaseRepository<Domain.Entities.School>, ISchoolRepository
    {
        public SchoolRepository(EntityContext contextEntity, DapperContext contextDapper) : base(contextEntity, contextDapper)
        {
            _contextEntity = contextEntity;
            _contextDapper = contextDapper;
        }

        //Terminar de mapear os dados
        public IQueryable<IQuery> GetSchoolStudents()
        {
            return _contextDapper
                .Connection
                .Query<SchoolStudentsQuery>(@"SELECT [EscNome] AS SchoolName, [EscNumeroDocumento] AS SchoolDocumentNumber, [EscTipoDocumento] AS SchoolTypeDocument, 
                                             [EstNome] AS StudentFirstName, [EstSobreNome] AS StudentLastName, [EstTipoEnsino] AS StudentETypeOfEducation, 
                                             [EstAnoLetivo] AS StudentAcademicYear, [EstSerie] AS StudentSerie, [EstTurma] AS StudentGrade, 
                                             [EstTurno] AS StudentShifts, [EstNumeroChamada] AS STudentCalledNumber
                                      FROM [EscEscola] INNER JOIN [EstEstudante] ON EscId = SchoolId",
                                            new {}).AsQueryable();
        }

        // Pesquisa de escola por número de CNPJ
        public IQuery GetSchool(string escdocumento)
        {
            return _contextDapper
                .Connection
                .Query<SchoolQuery>(@"SELECT [EscId] AS Id, [EscNome] AS Name, [EscNumeroDocumento] AS DocumentNumber, [EscTipoDocumento] AS Type, 
                                             [EscRua] AS Street, [EscEnderecoNumero] AS Number, [EscBairro] AS Neighborhood, [EscCidade] AS City, 
                                             [EscUf] AS StateName, [EscSiglaUf] AS Abbr, [EscPais] AS Country, [EscCep] AS ZipCode, 
                                             [EscTelefone] AS Phone 
                                      FROM [EscEscola]
                                      WHERE [EscNumeroDocumento] = @EscNumeroDocumento",
                                            new { EscNumeroDocumento = escdocumento }).FirstOrDefault();
        }

        // Verifica se a escola já está cadastrada
        public bool DocumentExists(string document)
        {
            var school = GetSchool(document);

            if (school != null)
                return true;

            return false;
        }
    }
}
