using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Domain.Contracts;
using Tekus.Core.Infrastructure.DataAccess;

namespace Infrastructure.DataAccess
{
    internal class TekusRepository<TEntity> : ITekusRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly TekusDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        #region Builders

        public TekusRepository(TekusDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        #endregion

        #region Methods
        public void Delete(Guid id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public TEntity GetByID(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        #endregion
    }
}
