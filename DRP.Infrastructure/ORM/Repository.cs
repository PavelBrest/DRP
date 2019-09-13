using DRP.Core.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRP.Infrastructure.ORM
{
    internal class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IHasId
    {
        public TEntity Add(TEntity entity, bool shouldSaveChanges = true)
        {
            return entity;
        }

        public IQueryable<TEntity> AddAll(IEnumerable<TEntity> entities, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> AddAsync(TEntity entity, bool shouldSaveChanges = true)
        {
            return Task.FromResult(entity);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            return Task.FromResult(entity);
        }

        public TEntity Delete(TEntity entity, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(TEntity entity, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
