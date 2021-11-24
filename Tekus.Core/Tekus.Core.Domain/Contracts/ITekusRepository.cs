using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tekus.Core.Domain.Contracts
{
    public interface ITekusRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> InsertAsync(TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        public bool Save();

    }
}
