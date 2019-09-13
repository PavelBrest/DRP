using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRP.Core.Data.Abstractions
{
    public interface IHasId
    {
        object Id { get; }

    }

    public interface IHasId<T> : IHasId
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        T Id { get; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }

    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, IHasId
    {
        TEntity Add(TEntity entity, bool shouldSaveChanges = true);
        IQueryable<TEntity> AddAll(IEnumerable<TEntity> entities, bool shouldSaveChanges = true);
        Task<TEntity> AddAsync(TEntity entity, bool shouldSaveChanges = true);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Delete(TEntity entity, bool shouldSaveChanges = true);
        bool Delete(object id, bool shouldSaveChanges = true);
        Task<TEntity> DeleteAsync(TEntity entity, bool shouldSaveChanges = true);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(object id, bool shouldSaveChanges = true);
        Task<bool> DeleteAsync(object id);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        TEntity Update(TEntity entity, bool shouldSaveChanges = true);
        Task<TEntity> UpdateAsync(TEntity entity, bool shouldSaveChanges = true);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
