using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tekus.Core.Domain.Contracts
{
    public interface ITekusRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(Guid id);
        Task<List<TEntity>> GetAll();
        void Insert(TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);

    }
}
