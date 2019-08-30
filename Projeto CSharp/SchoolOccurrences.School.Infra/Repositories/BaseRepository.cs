using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Infra.Contexts.Dapper;
using SchoolOccurrences.School.Infra.Contexts.Entity;
using SchoolOccurrences.School.Infra.Queries.Occurrence;
using SchoolOccurrences.School.Infra.Queries.School;
using SchoolOccurrences.School.Infra.Queries.Student;
using SchoolOccurrences.Shared.Commons.Interfaces.IQuery;
using System;
using System.Linq;

namespace SchoolOccurrences.School.Infra.Repositories
{
    // Classe responsável por implementar o básico que será usado nos repositorios
    public class BaseRepository<TEntity> : IBaseRepositoryDapper, IBaseRepositoryEntity<TEntity> where TEntity : class
    {
        public EntityContext _contextEntity;
        public DapperContext _contextDapper;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(EntityContext contextEntity, DapperContext contextDapper)
        {
            _contextEntity = contextEntity;
            _contextDapper = contextDapper;
            DbSet = contextEntity.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public TEntity GetById(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public void Remove(Guid Id)
        {
            DbSet.Remove(DbSet.Find(Id));
        }

        public int SaveChanges()
        {
            return _contextEntity.SaveChanges();
        }


        public IQueryable<IQuery> GetAllSchools()
        {
            return _contextDapper
                .Connection
                .Query<SchoolQuery>(@"SELECT [EscId] AS Id, [EscNome] AS Name, [EscNumeroDocumento] AS DocumentNumber, [EscTipoDocumento] AS Type, 
                                             [EscRua] AS Street, [EscEnderecoNumero] AS Number, [EscBairro] AS Neighborhood, [EscCidade] AS City, 
                                             [EscUf] AS StateName, [EscSiglaUf] AS Abbr, [EscPais] AS Country, [EscCep] AS ZipCode, 
                                             [EscTelefone] AS Phone 
                                      FROM [EscEscola]",
                                           new { }).AsQueryable();
        }

        public IQueryable<IQuery> GetAllStudents()
        {
            return _contextDapper
                .Connection
                .Query<StudentQuery>(@"SELECT [EstId] AS Id, [EstNome] AS FirstName, [EstSobreNome] AS LastName, [EstRua] AS Street, 
                                              [EstEnderecoNumero] AS Number, [EstBairro] AS Neighborhood, [EstCidade] AS City, 
                                              [EstUf] AS StateName, [EstSiglaUf] AS Abbr, [EstPais] AS Country, [EstCep] AS ZipCode, 
                                              [EstTipoEnsino] AS ETypeOfEducation, [EstAnoLetivo] AS AcademicYear, [EstDataNascimento] AS BirthDate,
                                              [EstSerie] AS Serie, [EstTurma] AS Grade, [EstTurno] AS Shifts, [EstNumeroChamada] AS CalledNumber, 
                                              [EstObservacao] AS Note
                                      FROM [EstEstudante]",
                                           new { }).AsQueryable();
        }

        public void Dispose()
        {
            _contextEntity.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<IQuery> GetAllOccurrences()
        {
            return _contextDapper
                .Connection
                .Query<OccurrenceQuery>(@"SELECT [OcrId] AS Id, [OcrTipo] AS OccurrenceType, [OcrCausa] AS Cause, [OcrDescricao] AS Description, 
                                                 [OcrSituacao] AS OccurrenceStatus, [OcrData] AS Date
                                          FROM [OcrOcorrencia]",
                                      new { }).AsQueryable();
        }
    }
}
