using System;

namespace SchoolOccurrences.School.Domain.Repositories.Interfaces
{
    // Definindo o contrato do repositorio base. Reuso de código
    public interface IBaseRepositoryEntity<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid Id);
        void Update(TEntity obj);
        void Remove(Guid Id);
        int SaveChanges();
    }
}
